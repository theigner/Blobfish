namespace Blobfish.TestConsole
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static string outputFilePath = "";

        static void Main(string[] args)
        {
            //// Create a new AnimlDocument
            AnimlDocument document = new AnimlDocument();

            //// Create Sample(s) in the AnimlDocument
            CreateSamples(ref document);

            //// Create ExperimentStep(s) in the AnimlDocument
            CreateExperimentSteps(ref document);

            ////Create AuditTrailEntry(s) in the AnimlDocument
            CreateAuditTrailEntries(ref document);

            //// Generate the AnIML document XML from the AnimlDocument object
            string docString = document.ToXml();

            //// Print the XML to the console
            Console.WriteLine("Generated AnIML document:");
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

            //// Create a new document from the generated XML (to test importing XML)
            AnimlDocument document2 = AnimlDocument.ReadFromString(docString);
            string docString2 = document2.ToXml();

            Console.WriteLine("AnIML document from import:");
            Console.WriteLine("=========================");
            Console.WriteLine(docString2);
            Console.WriteLine();

            //// Compare the initial XML with the one after reading from the XML
            Console.WriteLine("AnIML documents are equal:");
            Console.WriteLine("==========================");
            Console.WriteLine(docString.Equals(docString2, StringComparison.Ordinal) ? "YES" : "NO");
            Console.WriteLine();


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

        private static void CreateSamples(ref AnimlDocument document)
        {
            //// Initialize the SampleSet of the AnimlDocument
            document.SampleSet = new SampleSet();

            //// Create a sample with some dummy data
            Sample sample = new Sample("SampleName", "S-1234")
            {
                Barcode = "B-1234",
                Comment = "This is a comment",
                ContainerId = "C-1234",
                ContainerType = ContainerType.Simple,
                Derived = false,
                Id = "SampleId",
                LocationInContainer = "A1",
                SourceDataLocation = @"c:\test\1",
            };

            //// Initialize the TagSet for the Sample and add a Tag to it
            sample.TagSet = new TagSet();
            sample.TagSet.Tags.Add(new Tag("123", "456"));

            //// Create a category and a sub-category
            Category category = new Category("TestCategory")
            {
                Id = "CategoryId",
            };

            Category subCategory = new Category("SubCategory")
            {
                Id = "SubCategoryId",
            };

            //// Create a new Parameter with a double as value and assign it to the sub-categorys
            Parameter parameter = new Parameter("Param X1", 123.05);
            subCategory.Parameters.Add(parameter);

            //// Create a SeriesSet with two IndividualValueSets
            SeriesSet seriesSet = new SeriesSet("TestSeriesSetInd", 5);
            Series xData = new Series("xData", "xS", Dependency.Independent, SeriesType.Int32);
            IndividualValueSet xDataVals = new IndividualValueSet(new List<int>() { 1, 2, 3, 4, 5 });
            xData.ValueSets.Add(xDataVals);
            Series yData = new Series("yData", "yS", Dependency.Dependent, SeriesType.Int32);
            IndividualValueSet yDataVals = new IndividualValueSet(new List<int>() { 2, 8, 9, 2, 0 });
            yData.ValueSets.Add(yDataVals);
            seriesSet.Series.Add(xData);
            seriesSet.Series.Add(yData);

            //// Create a SeriesSet with two EncodedValueSets
            SeriesSet encSeriesSet = new SeriesSet("TestSeriesSetEnc", 4);
            Series xDataEnc = new Series("xDataEnc", "xSE", Dependency.Independent, SeriesType.Int32);
            EncodedValueSet xDataSetEnc = new EncodedValueSet(new List<int>() { 0, 1, 2, 3, 4, 5 });
            xDataEnc.ValueSets.Add(xDataSetEnc);
            Series yDataEnc = new Series("yDataEnc", "ySE", Dependency.Dependent, SeriesType.Float32);
            EncodedValueSet yDataSetEnc = new EncodedValueSet(new List<float>() { 0.1f, 0.2f, 0.3f, 3f, 4f, 5f });
            yDataEnc.ValueSets.Add(yDataSetEnc);
            encSeriesSet.Series.Add(xDataEnc);
            encSeriesSet.Series.Add(yDataEnc);

            //// Create a SeriesSet with two AutoIncrementedValueSets
            SeriesSet aincSeriesSet = new SeriesSet("TestSeriesSetAInc", 4);
            Series xDataAInc = new Series("xDataAInc", "xSAInc", Dependency.Independent, SeriesType.Int32);
            AutoIncrementedValueSet xDataSetAInc = new AutoIncrementedValueSet(0, 1);
            xDataAInc.ValueSets.Add(xDataSetAInc);
            Series yDataAInc = new Series("yDataAInc", "ySAInc", Dependency.Dependent, SeriesType.Float32);
            AutoIncrementedValueSet yDataSetAInc = new AutoIncrementedValueSet(0.0, 0.1);
            yDataAInc.ValueSets.Add(yDataSetAInc);
            aincSeriesSet.Series.Add(xDataAInc);
            aincSeriesSet.Series.Add(yDataAInc);

            //// Add the three ValueSets to the sub-categry
            subCategory.SeriesSets.Add(seriesSet);
            subCategory.SeriesSets.Add(encSeriesSet);
            subCategory.SeriesSets.Add(aincSeriesSet);

            //// Add the sub-categgory to the category
            category.Categories.Add(subCategory);

            /// Add the category to the sample
            sample.Categories.Add(category);

            //// Add the Sample to the SampleSet
            document.SampleSet.Samples.Add(sample);
        }

        private static void CreateExperimentSteps(ref AnimlDocument document)
        {
            //// Create an ExperimentStepSet that contains all the experiment data.
            ExperimentStepSet expStepSet = new ExperimentStepSet();

            //// Create a first ExperimentStep. This ExperimentStep will reference the Sample.
            ExperimentStep expStep1 = new ExperimentStep("FirstStep", "E-1");
            expStep1.Comment = "This is the 1st experiment step";

            //// Create the infrastructure that is needed to establish the reference between the ExperimentStep and the Sample.
            expStep1.Infrastructure = new Infrastructure();
            expStep1.Infrastructure.Timestamp = DateTime.Now;
            expStep1.Infrastructure.SampleReferencetSet = new SampleReferenceSet();
            expStep1.Infrastructure.SampleReferencetSet.SampleReferences.Add(new SampleReference(document.SampleSet.Samples[0].SampleId, "Sample under test.", SamplePurpose.Consumed));

            //// Create the method information for the ExperimentStep
            expStep1.Method = new Method();
            expStep1.Method.Author = new Author("John Doe", UserType.Human)
                                        {
                                            Affiliation = "Black Mesa Corp.",
                                            Email = "john.doe@black-mesa.corp",
                                            Location = "New Mexico",
                                            Phone = "+1 505 1234567",
                                            Role = "Lab Technician",
                                        };
            expStep1.Method.Device = new Device("pH Meter")
                                        {
                                            DeviceIdentifier = "PH-11-1",
                                            FirmwareVersion = "1.21a",
                                            Manufacturer = "pH Meter Manufacturing Corp.",
                                            SerialNumber = "PHM0815",
                                        };
            expStep1.Method.Software = new Software("pH Meter PC Software")
            {
                Manufacturer = "pH Meter Manufacturing Corp.",
                OperatingSystem = Environment.OSVersion.ToString(),
                Version = "2.08",
            };

            List<double> values = GenerateValues(50, 6, 3);

            //// Create a Result for the 1st ExperimentStep
            Result pHResult = new Result("pH");
            pHResult.SeriesSet = new SeriesSet("pH Measurement", 50);
            Series phTimeSeries = new Series("Time", "SER-PH-TIME", Dependency.Independent, SeriesType.Int32);
            phTimeSeries.PlotScale = PlotScale.Linear;
            phTimeSeries.ValueSets.Add(new AutoIncrementedValueSet(0, 1));
            pHResult.SeriesSet.Series.Add(phTimeSeries);
            Series phValueSeries = new Series("pH", "SER-PH-VALS", Dependency.Dependent, SeriesType.Float64);
            phValueSeries.PlotScale = PlotScale.Linear;
            phValueSeries.ValueSets.Add(new EncodedValueSet(values));
            pHResult.SeriesSet.Series.Add(phValueSeries);
            expStep1.Results.Add(pHResult);

            //// Add the 1st ExperimentStep to the ExperimentStepSet.
            expStepSet.ExperimentSteps.Add(expStep1);

            //// Create a second ExperimentStep. This ExperimentStep will reference the first ExperimentStep.
            ExperimentStep expStep2 = new ExperimentStep("SecondStep", "E-2");
            expStep2.Comment = "This is the 2nd experiment step";

            //// Create the infrastructure that is needed to establish the reference between the 1st and the 2nd ExperimentStep.
            expStep2.Infrastructure = new Infrastructure();
            expStep2.Infrastructure.Timestamp = DateTime.Now;
            expStep2.Infrastructure.ExperimentDataReferenceSet = new ExperimentDataReferenceSet();
            expStep2.Infrastructure.ExperimentDataReferenceSet.ExperimentDataReferences.Add(new ExperimentDataReference("E-1", "Data source", ExperimentDataPurpose.Consumed));

            //// Create a Result for the 2nd ExperimentStep
            Result calcResult = new Result("Calc");
            calcResult.SeriesSet = new SeriesSet("Calculated Results", 3);
            Series resultNamesSeries = new Series("ResultName", "SER-CALC-NAMES", Dependency.Independent, SeriesType.String);
            resultNamesSeries.PlotScale = PlotScale.None;
            resultNamesSeries.ValueSets.Add(new IndividualValueSet(new List<string>() { "Min", "Max", "Average" }));
            calcResult.SeriesSet.Series.Add(resultNamesSeries);
            Series resultValuesSeries = new Series("ResultValue", "SER-CALC-VALUES", Dependency.Dependent, SeriesType.Float64);
            resultValuesSeries.PlotScale = PlotScale.None;
            resultValuesSeries.ValueSets.Add(new IndividualValueSet(new List<double>() { values.Min(), values.Max(), values.Average() }));
            calcResult.SeriesSet.Series.Add(resultValuesSeries);
            expStep2.Results.Add(calcResult);

            //// Add the 2nd ExperimentStep to the ExperimentStepSet.
            expStepSet.ExperimentSteps.Add(expStep2);

            document.ExperimentStepSet = expStepSet;
        }

        private static void CreateAuditTrailEntries(ref AnimlDocument document)
        {
            document.AuditTrailEntrySet = new AuditTrailEntrySet();

            Author author = new Author("John Doe", UserType.Human);
            AuditTrailEntry auditTrailEntry = new AuditTrailEntry(DateTime.Now, author, Blobfish.Action.Created);
            auditTrailEntry.Comment = "Creation of the AnIML document.";
            document.AuditTrailEntrySet.AuditTrailEntries.Add(auditTrailEntry);
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
