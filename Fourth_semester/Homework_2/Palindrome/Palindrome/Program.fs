let rec strList i acc (str : string)=
    if i = str.Length then
        acc
    else
        strList
            (i + 1)
            (str.Chars(i) :: acc)
            (str)
        
let listOfPairs str = List.zip (List.rev(strList 0 [] str)) (strList 0 [] str)     

let rec check acc list =
    match list with
    | [] -> true
    | head :: tail ->
        match head with
            | (a, b) -> if a = b then
                            check acc tail
                        else
                            false

let isPalindrome1 = check true << listOfPairs

let isPalindrome2 str = List.forall2 (fun elem1 elem2 -> elem1 = elem2) (List.rev(strList 0 [] str)) (strList 0 [] str)

let isPalindrome3 str = List.ofSeq str = List.rev (List.ofSeq str)

[<EntryPoint>]
let main argv = 
//    printfn "%A" argv
    printfn "%b" (isPalindrome1 "AbvgdgvbA")
    printfn "%b" (isPalindrome2 "AbvgdvbA")
    printfn "%b" (isPalindrome3 "AbvgdvbA")
    0 // возвращение целочисленного кода выхода
