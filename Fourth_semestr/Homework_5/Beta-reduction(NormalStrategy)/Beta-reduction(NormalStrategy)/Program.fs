open Reducer
// Дополнительные сведения о F# см. на http://fsharp.org
// Дополнительную справку см. в проекте "Учебник по F#".

// ((λa.(λb.b b) (λb.b b))     b)         ((λc.(c b)) (λa.a)).

[<EntryPoint>]
let main argv = 
    //let expression = (Application (Application (Abstraction ("a", Application (Abstraction ("b", Application(Variable "b", Variable "b")), Abstraction ("b", Application(Variable "b", Variable "b")))), Variable "b"),  Application (Abstraction ("c", Application(Variable "c", Variable "b")),Abstraction("a", Variable "a"))))
    //let expression = (Application(Abstraction("x", Application(Variable("x"), Variable("x"))), Abstraction("x", Application(Variable("x"), Variable("x")))))
    let expression = (Application (Abstraction ("a", Application (Abstraction ("b", Application(Variable "b", Variable "b")), Abstraction ("b", Application(Variable "b", Variable "b")))), Variable "b"))
    print expression
    printfn ""
    printfn "%A" <| FV expression
    0 // возвращение целочисленного кода выхода
