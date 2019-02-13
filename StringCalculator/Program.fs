 namespace StringCalculator


 module calculator=

  let getIntValue(number:string)=
    if System.Text.RegularExpressions.Regex("^[0-9]+$").IsMatch number
    then System.Int32.Parse(number)
    else failwithf "Not A Number %s" number
 
  let Add (numbers:string) =
    match numbers.Length with 
    | 0 -> 
          0 
    | _ ->
          match numbers.Contains(",") with
          |false ->
             getIntValue(numbers) 
          |true ->
                let arrayOfNumbers= numbers.Split[|','|]
                getIntValue(arrayOfNumbers.[0]) + getIntValue(arrayOfNumbers.[1])

  