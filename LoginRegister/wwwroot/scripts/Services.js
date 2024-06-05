
const login = async () => {
    try {
        const user = {
            userName : document.getElementById("userNameRegister").value,
            password : document.getElementById("passwordRegister").value
        }
       
        const res = await fetch("../api/User/Login", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
        
        })
        if (!res.ok)
            throw new Error("The user doesnt exist please register or try again")
     
        const data = await res.json()

        localStorage.setItem("User", JSON.stringify(data))
        
        window.location.href = '../../htmls/Update.html'
       
    }
    catch (ex) {
        alert( "The user doesnt exist please register or try again")
    }
}
const register = async() => {
   
    try {
        const user = {
            UserName: document.getElementById("userName").value,
            Password: document.getElementById("password").value,
            FirstName: document.getElementById("firstName").value,
            LastName: document.getElementById("lastName").value,
        }
        if (!user.UserName || !user.Password)
            throw new Error("Error: all field are required or userName not email");

        const strong = await checkPassword();
        if (strong == 0)
            alert("Your password is weak, Enter password again!");
        else {
            const res = await fetch("../api/User", {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(user)
            })

            if (!res.ok)
               alert("The user doesnt add please try again")
            else {
                alert("The user added")
                document.getElementById("register").style.visibility = "hidden";
            }
           
        }
    }
    catch (ex) {
        console.log(ex)
    }

}
const moveToRegister = () => {
    document.getElementById("register").style.visibility = "visible";
}
const update = () => {
    document.getElementById("register").style.visibility = "visible";
    const userString = JSON.parse(localStorage.getItem("User"))
    document.getElementById("userName").value = userString.userName;
    document.getElementById("password").value = userString.password;
    document.getElementById("firstName").value = userString.firstName;
    document.getElementById("lastName").value = userString.lastName;
}
const save = async () => {
    const userString = localStorage.getItem("User")
    const userId = JSON.parse(userString).userId
    const userName = document.getElementById("userName").value
    const password = document.getElementById("password").value
    const firstName = document.getElementById("firstName").value
    const lastName = document.getElementById("lastName").value

    const user = { userName, password, firstName, lastName ,userId}
    if (!user.userName || !user.password )
        throw new Error("Error: all fields are required or user name not email");

    const strong =  checkPassword();
    if (strong == 0)
        alert("Your password is weak, Enter password again!");
    try {
        const res = await fetch(`../api/User/${userId}`,
            {
            method: "PUT",
            headers: {
                "Content-Type": "application/json"
            },
            body:JSON.stringify(user)

﻿
            })
    
        if (!res.ok)
            throw new Error("Error update user to server")
        localStorage.setItem("User", JSON.stringify(user))
        document.getElementById("register").style.visibility = "hidden";
       alert(`user ${JSON.parse(localStorage.getItem("User")).userName} was updated`)
    }
    catch (ex)
    {
        alert("All fields are required or user name not email")
        console.log(ex.message)
        
    }


}
const checkPassword = async () => {
    const pass = document.getElementById("password").value
    try {
        const check = await fetch("/api/user/CheckPassword", {
            method: 'POST',
            headers: {
                'Content-Type': "application/json"
            },
            body: JSON.stringify(pass)
        })
        if (!check.ok)
            throw new Error("Error: Check password strength failed")

        const score = await check.json()
        document.getElementById("progress").value = score;

        if (score >= 2)
            return 1;
        else
            return 0;
    }
    catch (err) {
        console.log(err)
    }

}
