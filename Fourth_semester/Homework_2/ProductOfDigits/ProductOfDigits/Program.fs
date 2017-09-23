let rec product acc num =
    if num / 10 = 0 then
        acc * num
    else
        if num % 10 = 0 then
            0
        else
            product
                (acc * (num % 10))
                (num / 10)


let rec listOfDigits num acc =
    if num / 10 = 0 then
        num :: acc
    else
        listOfDigits
            (num / 10)
            ((num % 10) :: acc)

let product1 num = List.fold(fun acc elem -> acc * elem) 1 (listOfDigits num []) 

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // возвращение целочисленного кода выхода
