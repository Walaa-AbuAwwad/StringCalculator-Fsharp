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
          match numbers.Contains(",") || numbers.Contains("\n") with
          |false ->
             getIntValue(numbers) 
          |true ->
                let numbers'= numbers.Replace('\n', ',')
                let arrayOfNumbers= numbers'.Split[|','|]
                let validNumbers= arrayOfNumbers |> Array.map (fun x-> getIntValue(x))
                Array.sum validNumbers

  