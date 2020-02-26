Imports System.Numerics
Imports Fractions
Imports Microsoft.VisualStudio.TestTools.UnitTesting

Namespace FractionConverter.Tests
    <TestClass>
    Public Class FractionTests
        <TestMethod>
        Sub Constructor_OneThird()
            Dim oneThird = New Fraction(numerator:=1, denominator:=3)

            Assert.AreEqual(New BigInteger(1), oneThird.Numerator)
            Assert.AreEqual(New BigInteger(3), oneThird.Denominator)
            Assert.IsTrue(oneThird.IsPositive)
            Assert.AreEqual(FractionState.IsNormalized, oneThird.State)
            Assert.AreEqual("1/3", oneThird.ToString())
        End Sub

        <TestMethod>
        Sub ToDecimal_FiveTenths()
            Dim fiveTenths = New Fraction(numerator:=5, denominator:=10, normalize:=False)

            Assert.AreNotEqual(FractionState.IsNormalized, fiveTenths.State)
            Assert.AreEqual("5/10", fiveTenths.ToString())
            Assert.AreEqual(0.5D, fiveTenths.ToDecimal())
        End Sub

        <TestMethod>
        Sub FromDecimal_OneSixteenth()
            Dim oneSixteenth = Fraction.FromDecimal(0.0625D)

            Assert.AreEqual(FractionState.IsNormalized, oneSixteenth.State)
            Assert.AreEqual("1/16", oneSixteenth.ToString())
            Assert.IsTrue(Fraction.FromString("1/8") > oneSixteenth)
            Assert.IsTrue(oneSixteenth > Fraction.FromString("1/32"))
        End Sub
    End Class
End Namespace
