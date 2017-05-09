module Program

let func x ls = List.map (fun y -> y * x) ls

let func'1 x : int list -> int list = List.map (fun y -> y * x)

let func'2 x : int list -> int list = List.map <| (*) x

let func'3 = List.map << (*)
