module ParseTree

type Tree =
    | Node of char * Tree * Tree
    | Tip of int

let rec calculate tree = 
    match tree with
    | Tip x -> x
    | Node (oper, left, right) ->
        match oper with
        | '+' -> calculate left + calculate right
        | '-' -> calculate left - calculate right
        | '*' -> calculate left * calculate right
        | '/' -> calculate left / calculate right
        | _ -> failwith "incorrect operator"