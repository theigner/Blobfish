namespace Blobfish.BuildersTestConsole
{
    using System;
    using System.Collections.Generic;

    using Blobfish.Builders;

    public class Program
    {
        private static string outputFilePath = @"c:\temp\Blobfish.BuildersTestConsole.animl";

        public static void Main(string[] args)
        {
            List<double> values = GenerateValues(50, 0, 14);

            AnimlDocumentBuilder documentBuilder = new AnimlDocumentBuilder()
                .WithSampleSet(
                    new SampleSetBuilder()
                        .WithId("ID-SampleSet")
                        .WithSample(
                            new SampleBuilder("TestSample", "ID-TestSample")
                                .WithBarcode("B1234567890")
                                .WithComment("This is a test sample.")
                                .WithContainerInfo("CONT-123", ContainerType.Determinate, "A/1")
                                .WithDerived(false)
                                .WithId("S-1")
                                .WithSourceDataLocation("http://documentstore/B1234567890/data")
                                .Build())
                        .Build())
                .WithExperimentStepSet(
                    new ExperimentStepSetBuilder()
                        .WithId("ID-ExperimentStepSet")
                        .WithExperimentStep(
                            new ExperimentStepBuilder("TestExperimentStep", "ID-ExperimentStep")
                                .WithComment("This is a test experiment step.")
                                .WithId("E-1")
                                .WithInfrastructure(
                                    new InfrastructureBuilder()
                                        .WithTimestamp(DateTime.Now)
                                        .WithSampleReferenceSet(
                                            new SampleReferenceSetBuilder()
                                                .WithSampleReference(new SampleReference("ID-TestSample", "Test sample", SamplePurpose.Consumed))
                                                .Build())
                                        .Build())
                                .WithMethod(
                                    new MethodBuilder()
                                        .WithAuthor(
                                            new AuthorBuilder("John Doe", UserType.Human)
                                                .WithAffiliation("Black Mesa Corp.")
                                                .WithEmail("john.doe@black-mesa.corp")
                                                .WithLocation("New Mexico")
                                                .WithPhone("+1 505 1234567")
                                                .WithRole("Lab Technician")
                                                .Build())
                                        .WithDevice(
                                            new DeviceBuilder("pH Meter")
                                                .WithDeviceIdentifier("PH-11-1")
                                                .WithFirmwareVersion("1.21a")
                                                .WithManufacturer("pH Meter Manufacturing Corp.")
                                                .WithSerialNumber("PHM0815")
                                                .Build())
                                        .WithId("M-1")
                                        .WithName("pH Value")
                                        .WithSoftware(
                                            new SoftwareBuilder("pH Meter PC Software")
                                                .WithManufacturer("pH Meter Manufacturing Corp.")
                                                .WithOperatingSystem(Environment.OSVersion.ToString())
                                                .WithVersion("2.08")
                                                .Build())
                                        .Build())
                                .WithResult(
                                    new ResultBuilder("pH")
                                        .WithSeriesSet(
                                            new SeriesSetBuilder("pH Measurement", values.Count)
                                                 .WithSeries(
                                                    new SeriesBuilder("Time", "SER-PH-TIME", Dependency.Independent, SeriesType.Int32)
                                                        .WithId("SER-TIME")
                                                        .WithPlotScale(PlotScale.Linear)
                                                        .WithUnit(Units.Second)
                                                        .WithAutoIncrementedValueSet(0, 1)
                                                        .WithVisible(true)
                                                        .Build())
                                                 .WithSeries(
                                                    new SeriesBuilder("pH values", "SER-PH-VALS", Dependency.Dependent, SeriesType.Float64)
                                                        .WithId("SER-VALS")
                                                        .WithPlotScale(PlotScale.Linear)
                                                        .WithUnit(Units.Arbitrary)
                                                        .WithEncodedValueSet(values)
                                                        .WithVisible(true)
                                                        .Build())
                                                 .Build())
                                        .Build())
                                .Build())
                        .Build());

            AnimlDocument document = documentBuilder.Build();
            string docString = documentBuilder.Build().ToXml();

            //// Print the XML to the console
            Console.WriteLine("Generated AnIML document using builders:");
            Console.WriteLine("=========================");
            Console.WriteLine(docString);
            Console.WriteLine();

            if (!string.IsNullOrEmpty(outputFilePath))
            {
                document.SaveAsFile(outputFilePath);

                Console.WriteLine("Saved AnIML document to file:");
                Console.WriteLine("=========================");
                Console.WriteLine($"--> {outputFilePath}");
                Console.WriteLine();
            }

            //// Validate the AnIML document against the AnIML core schema
            Console.WriteLine("Validating document against the AnIML Core Schema:");
            Console.WriteLine("==================================================");

            AnimlDocumentValidator validator = AnimlDocumentValidator.CreateValidatorForAnimlDocumentString(docString);
            if (!validator.Validate())
            {
                Console.WriteLine("Validation failed.");
                validator.ValidationMessages.ForEach(Console.WriteLine);
            }
            else
            {
                Console.WriteLine("Validation succeeded.");
            }
        }

        private static List<double> GenerateValues(int length, double min, double range)
        {
            List<double> values = new List<double>();

            Random rand = new Random();
            for (int i = 0; i < length; i++)
            {
                values.Add(rand.NextDouble() * range + min);
            }

            return values;
        }
    }
}
