module Reducer

type Term =
    | Variable of string
    | Abstraction of string * Term
    | Application of Term * Term

let alphabet = [ "a"; "b"; "c"; "d"; "e"; "f"; "g"; "h"; "i"; "j"; "k"; "l"; "m"; "n"; "o"; "p"; "q"; "r"; "s"; "t"; "u"; "v"; "w"; "x"; "y"; "z" ]

/// free variables of term
let FV T =
    let rec freeTR T acc =
        match T with
        | Variable x -> x :: acc
        | Application (S1, S2) -> let first = freeTR S1 acc
                                  let second = freeTR S2 acc
                                  List.append first second
        | Abstraction (x, S) -> let a = freeTR S acc
                                List.filter (fun elem -> elem <> x) a
    freeTR T []

//S [ x := T ] indicates substitution of T for X in S
let rec substitute inS forX ofT =
    match inS with
    | Variable x when x = forX -> ofT
    | Variable x -> inS
    | Application (S1, S2) -> Application (substitute S1 forX ofT, substitute S2 forX ofT)
    | Abstraction (y, S) -> match ofT with
                            | Variable z when y = forX -> inS
                            | _ when (not << List.contains y <| FV (ofT)) || (not << List.contains forX <| FV (S)) -> Abstraction(y, substitute S forX ofT)
                            | _ -> let z = List.head <| List.filter(fun elem -> not << List.contains elem <| List.append (FV S) (FV ofT)) alphabet
                                   let first = substitute S y <| Variable z
                                   let second = substitute first forX ofT
                                   Abstraction (z, second)

let rec print term =
    match term with
    | Variable x -> printf "%s" x
    | Abstraction (x, t) -> printf "%s" ("L" + x + ".")
                            print t
    | Application (t1, t2) -> printf "%s" "("
                              print t1
                              printf "%s" ")("
                              print t2
                              printf "%s" ")"

let rec reduction term =
    match term with
    | Application (S1, S2) -> let red = reduction S1
                              match red with
                              | Abstraction (x, T) -> reduction <| substitute T x S2
                              | Application (T1, T2) -> reduction <| Application (reduction T1, T2)
                              | Variable x -> Application (Variable x, S2)
    | Abstraction (x, T) -> Abstraction (x, reduction T)
    | Variable x -> Variable x
    