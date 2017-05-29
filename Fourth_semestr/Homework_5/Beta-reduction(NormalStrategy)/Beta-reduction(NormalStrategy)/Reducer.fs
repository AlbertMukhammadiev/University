module Reducer

type Term =
    | Variable of char
    | Abstraction of char * Term
    | Application of Term * Term

let rec print term =
    match term with
    | Variable x -> printf "%A" x
    | Abstraction (x, t) -> printf "%A" ("L" + x + ".")
                            print term
    | Application (t1, t2) -> print term
                              print term

let substitute y term =
    match term with
    | Variable x -> printf "%A" x
    | Abstraction (x, t) -> substitute t y
    | Application (t1, t2) -> substitute t1 y
                              substitute t2 y