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

// свободные вхождения переменной х в терм Т заменяются на терм S
let rec subst x T S =
        match T with
        | Variable y when x = y -> S
        | Variable y -> Variable y
        | Application (S1, S2) -> Application (subst x T S1, subst x T S2)
        | Abstraction (y, S) -> match T with
                                | Variable z when x = y -> Abstraction (y, S)
                                | _ when List.contains x <| FV T || List.contains y <| FV T -> Abstraction (y, subst x T S)
                                | _ -> let z = List.head <| List.filter (fun x -> not << List.contains x <| List.append (FV T) (FV S)) alphabet
                                       Abstraction (z, subst y (Variable z) <| subst x T S)

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
                              | Abstraction (x, T) -> let sub = subst x T S2
                                                      reduction sub
                              | Application (T1, T2) -> let reductedT1 = reduction T1
                                                        reduction <| Application (reductedT1, T2)
                              | Variable x -> Application (Variable x, S2)
    | Abstraction (x, T) -> let red = reduction T
                            Abstraction (x, red)
    | Variable x -> Variable x
    