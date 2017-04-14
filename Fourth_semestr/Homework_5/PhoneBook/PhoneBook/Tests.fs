module Tests

open Book
open NUnit.Framework
open FsUnit

//System.IO.Directory.SetCurrentDirectory "C:\Users\Альберт\Documents\GitHub\University\Fourth_semestr\Homework_5\PhoneBook\PhoneBook"

[<Test>]
let ``test of searching number of the Police`` () =
    read ()
    findByName "Police" |> should equal "112102"
     
[<Test>]
let ``test of searching the name by number 112144`` () =
    read ()
    findByNumber "112144" |> should equal "GasEmergency"

[<Test>]
let ``test of add to data base(checking number of records)`` () =
    read ()
    let prev = Seq.length records
    add ("BabushkaDedushka1", "25202")
    add ("BabushkaDedushka2", "23124")
    add ("MamaPapa", "31496")
    save ()
    read ()
    let current = Seq.length records
    current - prev |> should equal 3

[<Test>]
let ``test of add to data base(searching of the added record)`` () =
    read ()
    add ("DedMoroz", "88005553555")
    save ()
    read ()
    Seq.tryFind (fun (name, num) -> (name, num) = ("DedMoroz", "88005553555")) |> should not' (equal None)

[<Test>]
let ``test of save (checking number of records)`` () =
    read ()
    let length = Seq.length records
    add ("Matroskin", "82466")
    add ("Serega", "-") 
    save ()
    save ()
    save ()
    read ()
    Seq.length records |> should equal (2 + length)

[<Test>]
let ``adding two equal records`` () =
    read ()
    let length = Seq.length records
    add ("home", "31496")
    add ("home", "31496")
    save ()
    Seq.length records |> should equal (1 + length)