module Computation

/// first way
type MyInt =
    | Value of int
    | Invalid
    static member (+) (x, y) =
        match x with
        | Invalid -> Invalid
        | Value a -> match y with
                     | Invalid -> Invalid
                     | Value b -> Value <| a + b
    static member (*) (x, y) =
        match x with
        | Invalid -> Invalid
        | Value a -> match y with
                     | Invalid -> Invalid
                     | Value b -> Value <| a * b
    static member (/) (x, y) =
        match x with
        | Invalid -> Invalid
        | Value a -> match y with
                     | Invalid -> Invalid
                     | Value b -> Value <| a / b
    static member (-) (x, y) =
        match x with
        | Invalid -> Invalid
        | Value a -> match y with
                     | Invalid -> Invalid
                     | Value b -> Value <| a - b
    static member toInt x =
        try
            Value << int <| x
        with
        | :? System.FormatException as ex -> Invalid

type ConvertingBuilder() =
    member this.Bind(x:string, f) = f << MyInt.toInt <| x
    member this.Return(x) = x

/// another way
type ConvertingBuilder2 () =
    member this.Bind (x:string, f) =
        let result =
            try
                Some <| int x
            with
            | :? System.FormatException as ex -> None
        match result with
        | Some y -> f y
        | None -> None
    
    member this.Return (x:obj) =
        match x with
        | :? int as value -> Some value
        | :? string as str -> Some <| int str
        | _ -> None