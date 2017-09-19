module Reducer

type Term =
    | Variable of char
    | Abstraction of char * Term
    | Application of Term * Term

let alphabet = ['a' .. 'z']

/// free variables of term
let freeVars t =
    let rec freeTR t acc =
        match t with
        | Variable x -> x :: acc
        | Application (S1, S2) -> let first = freeTR S1 acc
                                  let second = freeTR S2 acc
                                  List.append first second
        | Abstraction (x, S) -> let a = freeTR S acc
                                List.filter (fun elem -> elem <> x) a
    freeTR t []

//S [ x := T ] indicates substitution of T for X in S
let rec substitute inS forX ofT =
    match inS with
    | Variable x when x = forX -> ofT
    | Variable x -> inS
    | Application (S1, S2) -> Application (substitute S1 forX ofT, substitute S2 forX ofT)
    | Abstraction (y, S) -> match ofT with
                            | Variable z when y = forX -> inS
                            | _ when (not << List.contains y <| freeVars (ofT)) || (not << List.contains forX <| freeVars (S)) -> Abstraction(y, substitute S forX ofT)
                            | _ -> let z = List.head <| List.filter(fun elem -> not << List.contains elem <| List.append (freeVars S) (freeVars ofT)) alphabet
                                   let first = substitute S y <| Variable z
                                   let second = substitute first forX ofT
                                   Abstraction (z, second)

let rec print term =
    match term with
    | Variable x -> printf "%c" x
    | Abstraction (x, t) -> printf "%s %c %s" "L" x "."
                            print t
    | Application (t1, t2) -> printf "%s" "("
                              print t1
                              printf "%s" ")("
                              print t2
                              printf "%s" ")"

let rec reduction term =
    match term with
    | Application (Abstraction (x, T), S) -> reduction <| substitute T x S
    | Application (S1, S2) -> Application (reduction S1, reduction S2)
    | Abstraction (x, T) -> Abstraction (x, reduction T)
    | Variable x -> Variable x
