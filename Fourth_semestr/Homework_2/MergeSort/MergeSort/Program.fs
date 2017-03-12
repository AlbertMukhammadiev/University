let rec split list half1 half2 =
    match list with
        | [] -> (half1, half2)
        | [x] -> (x :: half1, half2)
        | hat :: head :: tail -> split tail (hat :: half1) (head :: half2)

let rec merge list acc =
    match list with        
        | ([], []) -> List.rev acc
        | ([], head :: tail) -> merge ([], tail) (head :: acc)
        | (head :: tail, []) -> merge (tail, []) (head :: acc)
        | (head :: tail, h :: t) when head > h -> merge (head :: tail, t) (h :: acc)
        | (head :: tail, h :: t) -> merge (tail, h :: t) (head :: acc)

let rec mergesort list =
    match list with
        | [] -> []
        | [x] -> list
        | _ -> let (half1, half2) = split list [] []
               merge (mergesort half1, mergesort half2) []

let printList list = List.fold(fun acc elem -> printfn "%A" elem) () list        

[<EntryPoint>]
let main argv =
    let list = [5; 2; 8; 9; 4 ;1; 6;]
    printList (mergesort list)
    0 // возвращение целочисленного кода выхода
