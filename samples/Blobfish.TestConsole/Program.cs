namespace Blobfish.TestConsole
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        static void Main(string[] args)
        {
            //// Create a new AnimlDocument
            AnimlDocument document = new AnimlDocument();

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

            //// Generate the AnIML document XML from the AnimlDocument object
            string docString = document.ToXml();

            //// Print the XML to the console
            Console.WriteLine("Generated AnIML document:");
            Console.WriteLine("=========================");
            Console.WriteLine(docString);
            Console.WriteLine();

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
    }
}
