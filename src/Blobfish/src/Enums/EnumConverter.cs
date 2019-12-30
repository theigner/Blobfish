namespace Blobfish
{
    using System;
    using System.Xml.Linq;

    internal static class EnumConverter
    {
        internal static XElement GetXmlRepresentation(this Action action)
        {
            string actionString;

            switch (action)
            {
                case Action.Created:
                    {
                        actionString = "created";
                        break;
                    }

                case Action.Modified:
                    {
                        actionString = "modified";
                        break;
                    }

                case Action.Converted:
                    {
                        actionString = "converted";
                        break;
                    }

                case Action.Read:
                    {
                        actionString = "read";
                        break;
                    }

                case Action.Signed:
                    {
                        actionString = "signed";
                        break;
                    }

                case Action.Deleted:
                    {
                        actionString = "deleted";
                        break;
                    }

                default:
                    {
                        throw new ArgumentException("Specified Action value is not valid.");
                    }
            }

            return new XElement(NamespaceHelper.GetXName("Action"), actionString);
        }

        internal static Action ImportAction(this XElement actionElement)
        {
            switch (actionElement.Value)
            {
                case "created":
                    {
                        return Action.Created;
                    }

                case "modified":
                    {
                        return Action.Modified;
                    }

                case "converted":
                    {
                        return Action.Converted;
                    }

                case "read":
                    {
                        return Action.Read;
                    }

                case "signed":
                    {
                        return Action.Signed;
                    }

                case "deleted":
                    {
                        return Action.Deleted;
                    }

                default:
                    {
                        throw new ArgumentException("Specified XmlRepresentation is not a valid value.");
                    }
            }
        }

        internal static string GetXmlRepresentation(this ContainerType containerType)
        {
            switch (containerType)
            {
                case ContainerType.Simple:
                    {
                        return "simple";
                    }

                case ContainerType.Determinate:
                    {
                        return "determinate";
                    }

                case ContainerType.Indeterminate:
                    {
                        return "indeterminate";
                    }

                case ContainerType.RectangularTray:
                    {
                        return "rectangular tray";
                    }

                case ContainerType.Wells6:
                    {
                        return "6 wells";
                    }

                case ContainerType.Wells24:
                    {
                        return "24 wells";
                    }

                case ContainerType.Wells96:
                    {
                        return "96 wells";
                    }

                case ContainerType.Wells384:
                    {
                        return "384 wells";
                    }

                case ContainerType.Wells1536:
                    {
                        return "1536 wells";
                    }

                default:
                    {
                        throw new ArgumentException("Specified ContainerType value is not valid.");
                    }
            }
        }

        internal static ContainerType ImportContainerType(string xmlRepresentation)
        {
            switch (xmlRepresentation)
            {
                case "simple":
                    {
                        return ContainerType.Simple;
                    }

                case "determinate":
                    {
                        return ContainerType.Determinate;
                    }

                case "indeterminate":
                    {
                        return ContainerType.Indeterminate;
                    }

                case "rectangular_tray":
                    {
                        return ContainerType.RectangularTray;
                    }

                case "6_wells":
                    {
                        return ContainerType.Wells6;
                    }

                case "24_wells":
                    {
                        return ContainerType.Wells24;
                    }

                case "96 wells":
                    {
                        return ContainerType.Wells96;
                    }

                case "384 wells":
                    {
                        return ContainerType.Wells384;
                    }

                case "1536 wells":
                    {
                        return ContainerType.Wells1536;
                    }

                default:
                    {
                        throw new ArgumentException("Specified XmlRepresentation is not a valid value.");
                    }
            }
        }

        internal static string GetXmlRepresentation(this Dependency dependency)
        {
            switch (dependency)
            {
                case Dependency.Independent:
                    {
                        return "independent";
                    }

                case Dependency.Dependent:
                    {
                        return "dependent";
                    }

                default:
                    {
                        throw new ArgumentException("Specified Dependency value is not valid.");
                    }
            }
        }

        internal static Dependency ImportDependency(this XAttribute dependencyAttribute)
        {
            switch (dependencyAttribute.Value)
            {
                case "independent":
                    {
                        return Dependency.Independent;
                    }

                case "dependent":
                    {
                        return Dependency.Dependent;
                    }

                default:
                    {
                        throw new ArgumentException("Specified XmlRepresentation is not a valid value.");
                    }
            }
        }

        internal static string GetXmlRepresentation(this ExperimentDataPurpose experimentDataPurpose)
        {
            switch (experimentDataPurpose)
            {
                case ExperimentDataPurpose.Produced:
                    {
                        return "produced";
                    }

                case ExperimentDataPurpose.Consumed:
                    {
                        return "consumed";
                    }

                default:
                    {
                        throw new ArgumentException("Specified ExperimentDataPurpose value is not valid.");
                    }
            }
        }

        internal static ExperimentDataPurpose ImportExperimentDataPurpose(this XAttribute experimentDataPurposeAttribute)
        {
            switch (experimentDataPurposeAttribute.Value)
            {
                case "consumed":
                    {
                        return ExperimentDataPurpose.Consumed;
                    }

                case "produced":
                    {
                        return ExperimentDataPurpose.Produced;
                    }

                default:
                    {
                        throw new ArgumentException("Specified XmlRepresentation is not a valid value.");
                    }
            }
        }

        internal static string GetXmlRepresentation(this ParameterType parameterType)
        {
            switch (parameterType)
            {
                case ParameterType.Int32:
                    {
                        return "Int32";
                    }

                case ParameterType.Int64:
                    {
                        return "Int64";
                    }

                case ParameterType.Float32:
                    {
                        return "Float32";
                    }

                case ParameterType.Float64:
                    {
                        return "Float64";
                    }

                case ParameterType.String:
                    {
                        return "String";
                    }

                case ParameterType.Boolean:
                    {
                        return "Boolean";
                    }

                case ParameterType.DateTime:
                    {
                        return "DateTime";
                    }

                case ParameterType.EmbeddedXML:
                    {
                        return "EmbeddedXML";
                    }

                case ParameterType.PNG:
                    {
                        return "PNG";
                    }

                case ParameterType.SVG:
                    {
                        return "SVG";
                    }

                default:
                    {
                        throw new ArgumentException("Specified ParameterType value is not valid.");
                    }
            }
        }

        internal static ParameterType ImportParameterType(this XAttribute parameterTypeAttribute)
        {
            switch (parameterTypeAttribute.Value)
            {
                case "Int32":
                    {
                        return ParameterType.Int32;
                    }

                case "Int64":
                    {
                        return ParameterType.Int64;
                    }

                case "Float32":
                    {
                        return ParameterType.Float32;
                    }

                case "Float64":
                    {
                        return ParameterType.Float64;
                    }

                case "String":
                    {
                        return ParameterType.String;
                    }

                case "Boolean":
                    {
                        return ParameterType.Boolean;
                    }

                case "DateTime":
                    {
                        return ParameterType.DateTime;
                    }

                case "EmbeddedXML":
                    {
                        return ParameterType.EmbeddedXML;
                    }

                case "PNG":
                    {
                        return ParameterType.PNG;
                    }

                case "SVG":
                    {
                        return ParameterType.SVG;
                    }

                default:
                    {
                        throw new ArgumentException("Specified XmlRepresentation is not a valid value.");
                    }
            }
        }

        internal static string GetXmlRepresentation(this PlotScale plotScale)
        {
            switch (plotScale)
            {
                case PlotScale.Linear:
                    {
                        return "linear";
                    }

                case PlotScale.Log:
                    {
                        return "log";
                    }

                case PlotScale.Ln:
                    {
                        return "ln";
                    }

                case PlotScale.None:
                    {
                        return "none";
                    }

                default:
                    {
                        throw new ArgumentException("Specified PlotScale value is not valid.");
                    }
            }
        }

        internal static PlotScale ImportPlotScale(this XAttribute plotScaleAttribute)
        {
            switch (plotScaleAttribute.Value)
            {
                case "linear":
                    {
                        return PlotScale.Linear;
                    }

                case "log":
                    {
                        return PlotScale.Log;
                    }

                case "ln":
                    {
                        return PlotScale.Ln;
                    }

                case "none":
                    {
                        return PlotScale.None;
                    }

                default:
                    {
                        throw new ArgumentException("Specified XmlRepresentation is not a valid value.");
                    }
            }
        }

        internal static string GetXmlRepresentation(this SamplePurpose samplePurpose)
        {
            switch (samplePurpose)
            {
                case SamplePurpose.Produced:
                    {
                        return "produced";
                    }

                case SamplePurpose.Consumed:
                    {
                        return "consumed";
                    }

                default:
                    {
                        throw new ArgumentException("Specified SamplePurpose value is not valid.");
                    }
            }
        }

        internal static SamplePurpose ImportSamplePurpose(this XAttribute samplePurposeAttribute)
        {
            switch (samplePurposeAttribute.Value)
            {
                case "consumed":
                    {
                        return SamplePurpose.Consumed;
                    }

                case "produced":
                    {
                        return SamplePurpose.Produced;
                    }

                default:
                    {
                        throw new ArgumentException("Specified XmlRepresentation is not a valid value.");
                    }
            }
        }

        internal static string GetXmlRepresentation(this Scope scope)
        {
            switch (scope)
            {
                case Scope.Element:
                    {
                        return "element";
                    }

                case Scope.Attributes:
                    {
                        return "attributes";
                    }

                default:
                    {
                        throw new ArgumentException("Specified Scope value is not valid.");
                    }
            }
        }

        internal static Scope ImportScope(this XAttribute scopeAttribute)
        {
            switch (scopeAttribute.Value)
            {
                case "element":
                    {
                        return Scope.Element;
                    }

                case "attributes":
                    {
                        return Scope.Attributes;
                    }

                default:
                    {
                        throw new ArgumentException("Specified XmlRepresentation is not a valid value.");
                    }
            }
        }

        internal static string GetXmlRepresentation(this SeriesType seriesType)
        {
            switch (seriesType)
            {
                case SeriesType.Int32:
                    {
                        return "Int32";
                    }

                case SeriesType.Int64:
                    {
                        return "Int64";
                    }

                case SeriesType.Float32:
                    {
                        return "Float32";
                    }

                case SeriesType.Float64:
                    {
                        return "Float64";
                    }

                case SeriesType.String:
                    {
                        return "String";
                    }

                case SeriesType.Boolean:
                    {
                        return "Boolean";
                    }

                case SeriesType.DateTime:
                    {
                        return "DateTime";
                    }

                case SeriesType.EmbeddedXML:
                    {
                        return "EmbeddedXML";
                    }

                case SeriesType.PNG:
                    {
                        return "PNG";
                    }

                case SeriesType.SVG:
                    {
                        return "SVG";
                    }

                default:
                    {
                        throw new ArgumentException("Specified SeriesType value is not valid.");
                    }
            }
        }

        internal static SeriesType ImportSeriesType(this XAttribute seriesTypeAttribute)
        {
            switch (seriesTypeAttribute.Value)
            {
                case "Int32":
                    {
                        return SeriesType.Int32;
                    }

                case "Int64":
                    {
                        return SeriesType.Int64;
                    }

                case "Float32":
                    {
                        return SeriesType.Float32;
                    }

                case "Float64":
                    {
                        return SeriesType.Float64;
                    }

                case "String":
                    {
                        return SeriesType.String;
                    }

                case "Boolean":
                    {
                        return SeriesType.Boolean;
                    }

                case "DateTime":
                    {
                        return SeriesType.DateTime;
                    }

                case "EmbeddedXML":
                    {
                        return SeriesType.EmbeddedXML;
                    }

                case "PNG":
                    {
                        return SeriesType.PNG;
                    }

                case "SVG":
                    {
                        return SeriesType.SVG;
                    }

                default:
                    {
                        throw new ArgumentException("Specified XmlRepresentation is not a valid value.");
                    }
            }
        }

        internal static string GetXmlRepresentation(this SIBaseUnit baseUnit)
        {
            switch (baseUnit)
            {
                case SIBaseUnit.One:
                    {
                        return "1";
                    }

                case SIBaseUnit.Meter:
                    {
                        return "m";
                    }

                case SIBaseUnit.Kilogram:
                    {
                        return "kg";
                    }

                case SIBaseUnit.Second:
                    {
                        return "s";
                    }

                case SIBaseUnit.Ampere:
                    {
                        return "A";
                    }

                case SIBaseUnit.Kelvin:
                    {
                        return "K";
                    }

                case SIBaseUnit.Mol:
                    {
                        return "mol";
                    }

                case SIBaseUnit.Candela:
                    {
                        return "cd";
                    }

                default:
                    {
                        throw new ArgumentException("Specified SIBaseUnit value is not valid.");
                    }
            }
        }

        internal static SIBaseUnit ImportSIBaseUnit(this XElement siBaseUnitElement)
        {
            switch (siBaseUnitElement.Value)
            {
                case "1":
                    {
                        return SIBaseUnit.One;
                    }

                case "m":
                    {
                        return SIBaseUnit.Meter;
                    }

                case "kg":
                    {
                        return SIBaseUnit.Kilogram;
                    }

                case "s":
                    {
                        return SIBaseUnit.Second;
                    }

                case "A":
                    {
                        return SIBaseUnit.Ampere;
                    }

                case "K":
                    {
                        return SIBaseUnit.Kelvin;
                    }

                case "mol":
                    {
                        return SIBaseUnit.Mol;
                    }

                case "cd":
                    {
                        return SIBaseUnit.Candela;
                    }

                default:
                    {
                        throw new ArgumentException("Specified XmlRepresentation is not a valid value.");
                    }
            }
        }

        internal static string GetXmlRepresentation(this UserType userType)
        {
            switch (userType)
            {
                case UserType.Human:
                    {
                        return "human";
                    }

                case UserType.Device:
                    {
                        return "device";
                    }

                case UserType.Software:
                    {
                        return "software";
                    }

                default:
                    {
                        throw new ArgumentException("Specified UserType value is not valid.");
                    }
            }
        }

        internal static UserType ImportUserType(this XAttribute userTypeAttribute)
        {
            switch (userTypeAttribute.Value)
            {
                case "human":
                    {
                        return UserType.Human;
                    }

                case "device":
                    {
                        return UserType.Device;
                    }

                case "software":
                    {
                        return UserType.Software;
                    }

                default:
                    {
                        throw new ArgumentException("Specified XmlRepresentation is not a valid value.");
                    }
            }
        }
    }
}
