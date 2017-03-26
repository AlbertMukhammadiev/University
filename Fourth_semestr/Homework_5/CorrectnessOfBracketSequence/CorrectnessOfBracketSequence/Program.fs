let check (str : string) =
    let rec checkTR str stack=
        match str with
        | [] -> stack
        | head :: tail -> match head with
                          | "(" | "[" | "{" -> checkTR tail (head :: stack)
                          | ")" | "]" | "}" -> match stack with
                                               | [] -> [head]
                                               | top :: rest -> let expr = top + head
                                                                if expr <> "{}" || expr <> "()" || expr <> "[]" then
                                                                    stack
                                                                else
                                                                    checkTR tail rest
                          | x -> checkTR tail stack
    let s = List.map string <| List.ofSeq str
    (checkTR s []).IsEmpty

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    check "(){}[{(){}}]"
    0 // возвращение целочисленного кода выхода
