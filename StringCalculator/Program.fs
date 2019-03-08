 namespace StringCalculator

 open System


 module calculator=

  let getIntValue(number:string)=
    if System.Text.RegularExpressions.Regex("^-?[0-9]+$").IsMatch number //accept positive and negative integers
    then System.Int32.Parse(number)
    else failwithf "Not A Number %s" number

  let isAllnulls list = List.forall (fun elem -> elem = null) list
  
  let ifNegative(number:int)=
    if number<0 then string number else null

  let getPositive(number:int[])=
      let negatives =number |> Array.map (fun x-> ifNegative(x)) |> Array.toList
      if  isAllnulls negatives then number else failwithf "Negative not allowed %A" negatives 
  
  let ignoreGreaterThan1000(number:int)=
    if number >1000 then 0 else number

  let getSingleDelimiter(dlm:string)=
    let startIndex =dlm.IndexOf("[")+1
    dlm.Substring(startIndex)

  let getDelimiters(line:string)=
    match line.Contains("[") with
    |true ->
          let delimiters=line.Split[|']'|]
          delimiters |> Array.map (fun x-> getSingleDelimiter(x)) 
    |false ->
           let indexToStartDelmFrom =line.LastIndexOf("/")+1
           [|line.Substring(indexToStartDelmFrom) |]
           
  let rec replaceDelimitersWithComma (numbers:string) (delimiters:string[]) (index:int) = 
   if index = delimiters.Length || delimiters.[index] =""
   then numbers 
   else replaceDelimitersWithComma (numbers.Replace(delimiters.[index],",")) delimiters (index+1)

  let splitNumbers (numbers:string)=
     match numbers.StartsWith("//") with
     |false ->
             let numbers'= numbers.Replace('\n', ',')
             numbers'.Split[|','|]
     |true -> 
             let lines =numbers.Split[|'\n'|]
             let firstLine=lines.[0]
             let indexForNumbersWithoutDelm =firstLine.Length+1
             let numbersWithoutDelimiter =numbers.Substring(indexForNumbersWithoutDelm)
             let delimiters =getDelimiters firstLine
             let numbersWithoutDelimiter' =numbersWithoutDelimiter.Replace("\n", ",")
             let numbersWithoutDelimiter'' =replaceDelimitersWithComma numbersWithoutDelimiter' delimiters 0
             numbersWithoutDelimiter''.Split[|','|]

  let Add (numbers:string) =
    match numbers.Length with 
    | 0 -> 
          0 
    | _ -> match numbers.StartsWith("//") || numbers.Contains(",") || numbers.Contains("\n")with
          |false ->  getIntValue(numbers) //one number only
          |true -> //more than one number
                  let  arrayOfNumbers = splitNumbers numbers
                  let validNumbers= arrayOfNumbers |> Array.map (fun x-> getIntValue(x))
                  let positiveNumbers= getPositive validNumbers
                  let allNumbrsLessThan1000 =  positiveNumbers |> Array.map (fun x->ignoreGreaterThan1000(x))
                  Array.sum allNumbrsLessThan1000 
                  




  