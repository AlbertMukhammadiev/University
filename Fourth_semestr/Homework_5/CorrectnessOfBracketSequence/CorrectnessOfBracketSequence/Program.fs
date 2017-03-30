module Program

let check (str : string) =
    let rec checkTR str stack=
        match str with
        | [] -> stack
        | head :: tail -> match head with
                          | "(" | "[" | "{" -> checkTR tail (head :: stack)
                          | ")" | "]" | "}" -> match stack with
                                               | [] -> [head]
                                               | top :: rest -> let expr = top + head
                                                                if expr = "{}" || expr = "()" || expr = "[]" then
                                                                    checkTR tail rest
                                                                else
                                                                    stack
                          | x -> checkTR tail stack

    if str <> null then let s = List.map string <| List.ofSeq str
                        (checkTR s []).IsEmpty
                  else true
    