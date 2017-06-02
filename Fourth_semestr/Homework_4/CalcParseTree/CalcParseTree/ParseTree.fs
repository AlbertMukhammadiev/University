module ParseTree

type Operator =
    | Addition
    | Substraction
    | Multiplication
    | Division

type Tree =
    | Node of Operator * Tree * Tree
    | Tip of int

let rec calculate tree = 
    match tree with
    | Tip x -> x
    | Node (oper, left, right) ->
        match oper with
        | Addition -> calculate left + calculate right
        | Substraction -> calculate left - calculate right
        | Multiplication -> calculate left * calculate right
        | Division -> calculate left / calculate right