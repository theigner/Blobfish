namespace Blobfish
{
    using Blobfish.Builders;

    public static class Units
    {
        #region General

        public static Unit Arbitrary
        {
            get
            {
                return new UnitBuilder("arbitrary").WithSIUnit(new SIUnit(SIBaseUnit.One, 1, 1)).Build();
            }
        }

        public static Unit Bits
        {
            get
            {
                return new UnitBuilder("bits").WithSIUnit(new SIUnit(SIBaseUnit.One)).Build();
            }
        }

        public static Unit Percent
        {
            get
            {
                return new UnitBuilder("%").WithSIUnit(new SIUnit(SIBaseUnit.One, 1)).Build();
            }
        }

        public static Unit Counts
        {
            get
            {
                return new UnitBuilder("Counts").WithSIUnit(new SIUnit(SIBaseUnit.One, 1)).Build();
            }
        }

        public static Unit Cps
        {
            get
            {
                return new UnitBuilder("cps")
                    .WithSIUnit(new SIUnit(SIBaseUnit.One, 1))
                    .WithSIUnit(new SIUnit(SIBaseUnit.Second, exponent: -1)).Build();
            }
        }

        public static Unit Degree
        {
            get
            {
                return new UnitBuilder("°").WithSIUnit(new SIUnit(SIBaseUnit.One)).Build();
            }
        }

        #endregion

        #region Base SI Units - Mass

        public static Unit Gram
        {
            get
            {
                return new UnitBuilder("g").WithSIUnit(new SIUnit(SIBaseUnit.Kilogram, 1e-03)).Build();
            }
        }

        public static Unit Milligram
        {
            get
            {
                return new UnitBuilder("mg").WithSIUnit(new SIUnit(SIBaseUnit.Kilogram, 1e-06)).Build();
            }
        }

        public static Unit Microgram
        {
            get
            {
                return new UnitBuilder("µg").WithSIUnit(new SIUnit(SIBaseUnit.Kilogram, 1e-09)).Build();
            }
        }

        public static Unit Nanogram
        {
            get
            {
                return new UnitBuilder("ng").WithSIUnit(new SIUnit(SIBaseUnit.Kilogram, 1e-12)).Build();
            }
        }

        public static Unit Picogram
        {
            get
            {
                return new UnitBuilder("pg").WithSIUnit(new SIUnit(SIBaseUnit.Kilogram, 1e-15)).Build();
            }
        }

        public static Unit AtomicMassUnit
        {
            get
            {
                return new UnitBuilder("u").WithSIUnit(new SIUnit(SIBaseUnit.Kilogram, 1.660539040e-27)).Build();
            }
        }

        public static Unit MassToChargeRatio
        {
            get
            {
                return new UnitBuilder("m/z").WithSIUnit(new SIUnit(SIBaseUnit.One, 1)).Build();
            }
        }

        public static Unit MassToChargeRatioPerSecond
        {
            get
            {
                return new UnitBuilder("m/z")
                    .WithSIUnit(new SIUnit(SIBaseUnit.One, 1))
                    .WithSIUnit(new SIUnit(SIBaseUnit.Second, exponent: -1)).Build();
            }
        }

        #endregion

        #region Base SI Units - Length

        public static Unit Meter
        {
            get
            {
                return new UnitBuilder("m").WithSIUnit(new SIUnit(SIBaseUnit.Meter, 1, 1)).Build();
            }
        }

        public static Unit Centimeter
        {
            get
            {
                return new UnitBuilder("cm").WithSIUnit(new SIUnit(SIBaseUnit.Meter, 1e-2, 1)).Build();
            }
        }

        public static Unit Millimeter
        {
            get
            {
                return new UnitBuilder("mm").WithSIUnit(new SIUnit(SIBaseUnit.Meter, 1e-3, 1)).Build();
            }
        }

        public static Unit Micrometer
        {
            get
            {
                return new UnitBuilder("µm").WithSIUnit(new SIUnit(SIBaseUnit.Meter, 1e-6, 1)).Build();
            }
        }

        public static Unit Nanometer
        {
            get
            {
                return new UnitBuilder("nm").WithSIUnit(new SIUnit(SIBaseUnit.Meter, 1e-9, 1)).Build();
            }
        }

        public static Unit Picometer
        {
            get
            {
                return new UnitBuilder("pm").WithSIUnit(new SIUnit(SIBaseUnit.Meter, 1e-12, 1)).Build();
            }
        }

        public static Unit Angstrom
        {
            get
            {
                return new UnitBuilder("Å").WithSIUnit(new SIUnit(SIBaseUnit.Meter, 1e-10, 1)).Build();
            }
        }

        public static Unit Inch
        {
            get
            {
                return new UnitBuilder("in").WithSIUnit(new SIUnit(SIBaseUnit.Meter, 0.0254, 1)).Build();
            }
        }

        #endregion

        #region Base SI Units - Temperature

        public static Unit DegreeCelcius
        {
            get
            {
                return new UnitBuilder("°C").WithSIUnit(new SIUnit(SIBaseUnit.Kelvin, 1, 1, -273.15)).Build();
            }
        }

        public static Unit Kelvin
        {
            get
            {
                return new UnitBuilder("K").WithSIUnit(new SIUnit(SIBaseUnit.Kelvin, 1, 1, 0)).Build();
            }
        }

        public static Unit DegreeFahrenheit
        {
            get
            {
                return new UnitBuilder("°F").WithSIUnit(new SIUnit(SIBaseUnit.Kelvin, 1.8, 1, -459.67)).Build();
            }
        }

        #endregion

        #region Base SI-Units - Time

        public static Unit Hour
        {
            get
            {
                return new UnitBuilder("h").WithSIUnit(new SIUnit(SIBaseUnit.Second, 3600)).Build();
            }
        }

        public static Unit Minute
        {
            get
            {
                return new UnitBuilder("min").WithSIUnit(new SIUnit(SIBaseUnit.Second, 60)).Build();
            }
        }

        public static Unit Second
        {
            get
            {
                return new UnitBuilder("s").WithSIUnit(new SIUnit(SIBaseUnit.Second)).Build();
            }
        }

        public static Unit Millisecond
        {
            get
            {
                return new UnitBuilder("K").WithSIUnit(new SIUnit(SIBaseUnit.Second, 1e-3)).Build();
            }
        }

        public static Unit Microsecond
        {
            get
            {
                return new UnitBuilder("µs").WithSIUnit(new SIUnit(SIBaseUnit.Second, 1e-6)).Build();
            }
        }

        public static Unit Nanosecond
        {
            get
            {
                return new UnitBuilder("ns").WithSIUnit(new SIUnit(SIBaseUnit.Second, 1e-9)).Build();
            }
        }

        #endregion

        #region Base SI-Units - Frequency

        public static Unit Hertz
        {
            get
            {
                return new UnitBuilder("Hz").WithSIUnit(new SIUnit(SIBaseUnit.Second, 1, -1)).Build();
            }
        }

        public static Unit Kilohertz
        {
            get
            {
                return new UnitBuilder("kHz").WithSIUnit(new SIUnit(SIBaseUnit.Second, 1e+3, -1)).Build();
            }
        }

        #endregion

        #region Base SI-Units - Voltage

        public static Unit Kilovolt
        {
            get
            {
                return new UnitBuilder("kV")
                    .WithSIUnit(new SIUnit(SIBaseUnit.Kilogram, 1e+3))
                    .WithSIUnit(new SIUnit(SIBaseUnit.Meter, exponent: 2))
                    .WithSIUnit(new SIUnit(SIBaseUnit.Ampere, exponent: -1))
                    .WithSIUnit(new SIUnit(SIBaseUnit.Second, exponent: -3)).Build();
            }
        }

        public static Unit Volt
        {
            get
            {
                return new UnitBuilder("V")
                    .WithSIUnit(new SIUnit(SIBaseUnit.Kilogram))
                    .WithSIUnit(new SIUnit(SIBaseUnit.Meter, exponent: 2))
                    .WithSIUnit(new SIUnit(SIBaseUnit.Ampere, exponent: -1))
                    .WithSIUnit(new SIUnit(SIBaseUnit.Second, exponent: -3)).Build();
            }
        }

        public static Unit Millivolt
        {
            get
            {
                return new UnitBuilder("mV")
                    .WithSIUnit(new SIUnit(SIBaseUnit.Kilogram, 1e-3))
                    .WithSIUnit(new SIUnit(SIBaseUnit.Meter, exponent: 2))
                    .WithSIUnit(new SIUnit(SIBaseUnit.Ampere, exponent: -1))
                    .WithSIUnit(new SIUnit(SIBaseUnit.Second, exponent: -3)).Build();
            }
        }

        public static Unit Microvolt
        {
            get
            {
                return new UnitBuilder("µV")
                    .WithSIUnit(new SIUnit(SIBaseUnit.Kilogram, 1e-6))
                    .WithSIUnit(new SIUnit(SIBaseUnit.Meter, exponent: 2))
                    .WithSIUnit(new SIUnit(SIBaseUnit.Ampere, exponent: -1))
                    .WithSIUnit(new SIUnit(SIBaseUnit.Second, exponent: -3)).Build();
            }
        }

        public static Unit Nanovolt
        {
            get
            {
                return new UnitBuilder("nV")
                    .WithSIUnit(new SIUnit(SIBaseUnit.Kilogram, 1e-9))
                    .WithSIUnit(new SIUnit(SIBaseUnit.Meter, exponent: 2))
                    .WithSIUnit(new SIUnit(SIBaseUnit.Ampere, exponent: -1))
                    .WithSIUnit(new SIUnit(SIBaseUnit.Second, exponent: -3)).Build();
            }
        }

        public static Unit Picovolt
        {
            get
            {
                return new UnitBuilder("pV")
                    .WithSIUnit(new SIUnit(SIBaseUnit.Kilogram, 1e-12))
                    .WithSIUnit(new SIUnit(SIBaseUnit.Meter, exponent: 2))
                    .WithSIUnit(new SIUnit(SIBaseUnit.Ampere, exponent: -1))
                    .WithSIUnit(new SIUnit(SIBaseUnit.Second, exponent: -3)).Build();
            }
        }

        #endregion

        #region Base SI-Units - Current

        public static Unit Ampere
        {
            get
            {
                return new UnitBuilder("A").WithSIUnit(new SIUnit(SIBaseUnit.Ampere)).Build();
            }
        }

        public static Unit Milliampere
        {
            get
            {
                return new UnitBuilder("mA").WithSIUnit(new SIUnit(SIBaseUnit.Ampere, 1e-3)).Build();
            }
        }

        public static Unit Microampere
        {
            get
            {
                return new UnitBuilder("µA").WithSIUnit(new SIUnit(SIBaseUnit.Ampere, 1e-6)).Build();
            }
        }

        public static Unit Nanoampere
        {
            get
            {
                return new UnitBuilder("nA").WithSIUnit(new SIUnit(SIBaseUnit.Ampere, 1e-9)).Build();
            }
        }

        public static Unit Picoampere
        {
            get
            {
                return new UnitBuilder("pA").WithSIUnit(new SIUnit(SIBaseUnit.Ampere, 1e-12)).Build();
            }
        }

        public static Unit Femtoampere
        {
            get
            {
                return new UnitBuilder("fA").WithSIUnit(new SIUnit(SIBaseUnit.Ampere, 1e-15)).Build();
            }
        }

        #endregion

        #region Base SI-Units - Optical

        public static Unit Transmittance
        {
            get
            {
                return new UnitBuilder("T").WithSIUnit(new SIUnit(SIBaseUnit.One, 1, 1)).Build();
            }
        }

        public static Unit Absorption
        {
            get
            {
                return new UnitBuilder("AU").WithSIUnit(new SIUnit(SIBaseUnit.One, 1, 1)).Build();
            }
        }

        public static Unit RefractiveIndex
        {
            get
            {
                return new UnitBuilder("RIU").WithSIUnit(new SIUnit(SIBaseUnit.One, 1, 1)).Build();
            }
        }

        #endregion

        #region Derived Units - Volume

        public static Unit Liter
        {
            get
            {
                return new UnitBuilder("L")
                    .WithSIUnit(new SIUnit(SIBaseUnit.Meter, 1e-03, 3))
                    .Build();
            }
        }

        public static Unit Milliliter
        {
            get
            {
                return new UnitBuilder("L")
                    .WithSIUnit(new SIUnit(SIBaseUnit.Meter, 1e-06, 3))
                    .Build();
            }
        }

        public static Unit Microliter
        {
            get
            {
                return new UnitBuilder("L")
                    .WithSIUnit(new SIUnit(SIBaseUnit.Meter, 1e-09, 3))
                    .Build();
            }
        }

        public static Unit Nanoliter
        {
            get
            {
                return new UnitBuilder("L")
                    .WithSIUnit(new SIUnit(SIBaseUnit.Meter, 1e-12, 3))
                    .Build();
            }
        }

        #endregion

        #region Derived Units - Concentration

        public static Unit GramPerMilliliter
        {
            get
            {
                return new UnitBuilder("g/mL")
                    .WithSIUnit(new SIUnit(SIBaseUnit.Kilogram, 1e-03, 1))
                    .WithSIUnit(new SIUnit(SIBaseUnit.Meter, 1e-06, -3))
                    .Build();
            }
        }

        public static Unit MilligramPerMilliliter
        {
            get
            {
                return new UnitBuilder("mg/mL")
                    .WithSIUnit(new SIUnit(SIBaseUnit.Kilogram, 1e-06, 1))
                    .WithSIUnit(new SIUnit(SIBaseUnit.Meter, 1e-06, -3))
                    .Build();
            }
        }

        public static Unit MikrogramPerMilliliter
        {
            get
            {
                return new UnitBuilder("µg/mL")
                    .WithSIUnit(new SIUnit(SIBaseUnit.Kilogram, 1e-09, 1))
                    .WithSIUnit(new SIUnit(SIBaseUnit.Meter, 1e-06, -3))
                    .Build();
            }
        }

        public static Unit NanogramPerMilliliter
        {
            get
            {
                return new UnitBuilder("ng/mL")
                    .WithSIUnit(new SIUnit(SIBaseUnit.Kilogram, 1e-12, 1))
                    .WithSIUnit(new SIUnit(SIBaseUnit.Meter, 1e-06, -3))
                    .Build();
            }
        }

        public static Unit MililiterPerMilliliter
        {
            get
            {
                return new UnitBuilder("mL/mL")
                    .WithSIUnit(new SIUnit(SIBaseUnit.Meter, 1e-06, 3))
                    .WithSIUnit(new SIUnit(SIBaseUnit.Meter, 1e-06, -3))
                    .Build();
            }
        }

        public static Unit MililiterPerLiter
        {
            get
            {
                return new UnitBuilder("mL/L")
                    .WithSIUnit(new SIUnit(SIBaseUnit.Meter, 1e-06, 3))
                    .WithSIUnit(new SIUnit(SIBaseUnit.Meter, 1e-03, -3))
                    .Build();
            }
        }

        public static Unit MolPerLiter
        {
            get
            {
                return new UnitBuilder("mol/L")
                    .WithSIUnit(new SIUnit(SIBaseUnit.Mol, 1, 1))
                    .WithSIUnit(new SIUnit(SIBaseUnit.Meter, 1e-03, -3))
                    .Build();
            }
        }

        public static Unit MikrogramPerGram
        {
            get
            {
                return new UnitBuilder("µg/g")
                    .WithSIUnit(new SIUnit(SIBaseUnit.Kilogram, 1e-09, 1))
                    .WithSIUnit(new SIUnit(SIBaseUnit.Kilogram, 1e-03, -1))
                    .Build();
            }
        }

        public static Unit KilogramPerSquareCentimeter
        {
            get
            {
                return new UnitBuilder("kgf/cm²")
                    .WithSIUnit(new SIUnit(SIBaseUnit.Kilogram, exponent: 1))
                    .WithSIUnit(new SIUnit(SIBaseUnit.Meter, 1e-04, -2))
                    .Build();
            }
        }

        #endregion

        #region Derived Units - Current per Voltage

        public static Unit AmperePerVolt
        {
            get
            {
                return new UnitBuilder("A/V")
                    .WithSIUnit(new SIUnit(SIBaseUnit.Ampere, exponent: 2))
                    .WithSIUnit(new SIUnit(SIBaseUnit.Second, exponent: 3))
                    .WithSIUnit(new SIUnit(SIBaseUnit.Kilogram, exponent: -1))
                    .WithSIUnit(new SIUnit(SIBaseUnit.Meter, exponent: -2))
                    .Build();
            }
        }

        #endregion

        #region Derived Units - Bandwidth / Voltage per Time

        public static Unit MillivoltPerSecond
        {
            get
            {
                return new UnitBuilder("mV/s")
                    .WithSIUnit(new SIUnit(SIBaseUnit.Kilogram, 1e-3))
                    .WithSIUnit(new SIUnit(SIBaseUnit.Meter, exponent: 2))
                    .WithSIUnit(new SIUnit(SIBaseUnit.Ampere, exponent: -1))
                    .WithSIUnit(new SIUnit(SIBaseUnit.Second, exponent: -4)).Build();
            }
        }

        public static Unit MikrovoltPerSecond
        {
            get
            {
                return new UnitBuilder("µV/s")
                    .WithSIUnit(new SIUnit(SIBaseUnit.Kilogram, 1e-6))
                    .WithSIUnit(new SIUnit(SIBaseUnit.Meter, exponent: 2))
                    .WithSIUnit(new SIUnit(SIBaseUnit.Ampere, exponent: -1))
                    .WithSIUnit(new SIUnit(SIBaseUnit.Second, exponent: -4)).Build();
            }
        }

        #endregion

        #region Derived Units - Velocity

        public static Unit CentimeterPerSecond
        {
            get
            {
                return new UnitBuilder("cm/s")
                    .WithSIUnit(new SIUnit(SIBaseUnit.Meter, 1e-02, 1))
                    .WithSIUnit(new SIUnit(SIBaseUnit.Second, exponent: -1)).Build();
            }
        }

        public static Unit MeterPerSecond
        {
            get
            {
                return new UnitBuilder("m/s")
                    .WithSIUnit(new SIUnit(SIBaseUnit.Meter, exponent: 1))
                    .WithSIUnit(new SIUnit(SIBaseUnit.Second, exponent: -1)).Build();
            }
        }

        public static Unit KilometerPerHour
        {
            get
            {
                return new UnitBuilder("km/h")
                    .WithSIUnit(new SIUnit(SIBaseUnit.Meter, 1e03, 1))
                    .WithSIUnit(new SIUnit(SIBaseUnit.Second, 3600, -1)).Build();
            }
        }

        #endregion

        #region Derived Units - Energy

        public static Unit Electronvolt
        {
            get
            {
                return new UnitBuilder("eV")
                    .WithSIUnit(new SIUnit(SIBaseUnit.Kilogram, 1.602176634, 1))
                    .WithSIUnit(new SIUnit(SIBaseUnit.Meter, exponent: 2))
                    .WithSIUnit(new SIUnit(SIBaseUnit.Second, exponent: -2)).Build();
            }
        }

        #endregion

        #region Derived Units - Pressure

        #endregion

        #region Derived Units - Density

        #endregion

        #region Derived Units - Molar Mass

        #endregion

        #region Derived Units - Temperature change per time

        #endregion

        #region Derived Units - Volume per time and derived units

        #endregion

        #region Derived Units - Pressure change per time

        #endregion

        #region Derived Units - Other rate definitions

        #endregion
    }
}
