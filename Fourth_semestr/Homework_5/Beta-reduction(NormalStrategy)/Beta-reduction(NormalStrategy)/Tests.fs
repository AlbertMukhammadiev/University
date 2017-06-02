module Tests

open Reducer
open FsUnit
open NUnit.Framework

[<Test>]
let ``without changes`` () =
    let expr = (Abstraction ('x', Variable 'x'))
    reduction expr |> should equal expr

[<Test>]
let ``Test of reduction (λx. x) ((λx. x) (λz. (λx.x) z))`` () =
    let expr = (Application(Abstraction ('x', Variable 'x'), Application(Abstraction('x',Variable 'x'),(Abstraction('z', Application(Abstraction('x', Variable 'x'), Variable 'z'))))))
    reduction expr |> should equal <| Abstraction ('z', Variable 'z')

[<Test>]
let ``Test of FV (((λa.(λb.b b) (λb.b b)) b) ((λc.(c b)) (λa.a)))`` () =
    let expr = (Application (Application (Abstraction ('a', Application (Abstraction ('b', Application(Variable 'b', Variable 'b')), Abstraction ('b', Application(Variable 'b', Variable 'b')))), Variable 'b'),  Application (Abstraction ('c', Application(Variable 'c', Variable 'b')),Abstraction('a', Variable 'a'))))
    FV expr |> should equal [ 'b'; 'b']

[<Test>]
let ``Test of substitution of (λa.a a) for a in (λa.y)`` () =
    let S = Abstraction('a', Variable 'y')
    let T = Abstraction('a', Application(Variable('a'), Variable('a')))
    let x = 'a'
    substitute S x T |> should equal <| Abstraction (x, Variable 'y')