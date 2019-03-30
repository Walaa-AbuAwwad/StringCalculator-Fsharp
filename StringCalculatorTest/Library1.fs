 module testModule
 open StringCalculator
 open NUnit.Framework


 [<Test>]
    let ``inValid Number``()=
     Assert.DoesNotThrow(fun()-> (calculator.Add "77,7" |>ignore))
      
 [<Test>]
    let ``when empty -> return 0``()=
      let expected = calculator.Add ""
      Assert.AreEqual(0,expected)

 [<Test>]
    let ``when one number -> return number``()=
      let expected = calculator.Add "662"
      Assert.AreEqual(662,expected)

 [<Test>]
    let ``Add two numbers splited by (,)``()=
      let expected = calculator.Add "11,33"
      Assert.AreEqual(44,expected)

 [<Test>]
    let ``Add more than two numbers splited by (,)``()=
      let expected = calculator.Add "11,33,11,10"
      Assert.AreEqual(65,expected)

 [<Test>]
    let ``Add numbers splited by (\n)``()=
      let expected = calculator.Add "11\n33\n11"
      Assert.AreEqual(55,expected)
   
 [<Test>]
    let ``Add more than two numbers splited by (\n) and (,)``()=
      let expected = calculator.Add "11\n33,11\n10"
      Assert.AreEqual(65,expected)
      
 [<Test>]
    let ``Add with new Delimiter with one char``()=
      let expected = calculator.Add "//;\n11\n33,11;10"
      Assert.AreEqual(65,expected)
      let expected = calculator.Add "//*\n11*33,11,10"
      Assert.AreEqual(65,expected)

 [<Test>]
    let ``Add negative numbers``()=
      Assert.DoesNotThrow(fun()-> (calculator.Add "77,2" |>ignore))

 [<Test>]
    let ``Ignore numbers greater than 1000``()=
      let expected = calculator.Add "//*\n11*33,1199,10"
      Assert.AreEqual(54,expected)
       
 [<Test>]
    let ``Add with new Delimiter with more than one char``()=
      let expected = calculator.Add "//[**]\n11\n33**11,10"
      Assert.AreEqual(65,expected)
      let expected = calculator.Add "//[&^]\n11\n33&^11,10"
      Assert.AreEqual(65,expected)

 [<Test>]
    let ``Add with multiple delimiters``()=
      let expected = calculator.Add "//[&][*]\n11&33*11*10"
      Assert.AreEqual(65,expected)
      let expected = calculator.Add "//[mm][**]\n11\n33**11,10"
      Assert.AreEqual(65,expected)
      let expected = calculator.Add "//[&*%][**]\n11\n33**11&*%10"
      Assert.AreEqual(65,expected)

