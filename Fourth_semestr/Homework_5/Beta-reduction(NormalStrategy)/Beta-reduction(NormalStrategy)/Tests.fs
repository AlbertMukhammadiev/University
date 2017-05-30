module Tests

open Reducer
open FsUnit
open NUnit.Framework

//let expression = (Application (Application (Abstraction ("a", Application (Abstraction ("b", Application(Variable "b", Variable "b")), Abstraction ("b", Application(Variable "b", Variable "b")))), Variable "b"),  Application (Abstraction ("c", Application(Variable "c", Variable "b")),Abstraction("a", Variable "a"))))
    //let expression = (Application(Abstraction("x", Application(Variable("x"), Variable("x"))), Abstraction("x", Application(Variable("x"), Variable("x")))))
    //let expression = (Application (Abstraction ("a", Application (Abstraction ("b", Application(Variable "b", Variable "b")), Abstraction ("b", Application(Variable "b", Variable "b")))), Variable "b"))

[<Test>]
let ``Test of reduction (Lx. x) ((Lx. x) (Lz. (Lx.x) z))`` () =
    reduction (Application(Abstraction ("x", Variable "x"), Application(Abstraction("x",Variable "x"),(Abstraction("z", Application(Abstraction("x", Variable "x"), Variable "z")))))) |> should equal <| Abstraction ("z", Variable "z")