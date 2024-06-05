let allPrice=0;
const onLoad = () => {
    allPrice = 0;
    const tbody = document.querySelector('tbody');
    tbody.replaceChildren([]);
    let basketList = JSON.parse(sessionStorage.getItem("basket"));
    for (let i = 0; i < basketList.length;i++)
        drawProduct(basketList[i])
    document.getElementById("itemCount").innerText = basketList.length
    document.getElementById("totalAmount").innerText = allPrice
}
const drawProduct = (product) => {
  
    allPrice += product.price
    const temp = document.getElementById('temp-row')
    const clone = temp.content.cloneNode(true)

    clone.querySelector(".image").src = "../pictures/products/" + product.image.trim()+".png"
    clone.querySelector(".itemName").innerText = product.description
    clone.querySelector(".price").innerText = product.price
    clone.querySelector("button").addEventListener('click', () => deleteProduct(product))


    const tbody = document.querySelector('tbody');
    tbody.appendChild(clone)

   
}
const deleteProduct = (product) => {
    
    let basketList = JSON.parse(sessionStorage.getItem("basket"));

    let basketListNew = [];
    let count = 0;
    for (let i = 0; i < basketList.length; i++) {

        if (basketList[i].prodId != product.prodId || count != 0)

            basketListNew.push(basketList[i])
        else count++;

    }
 
  
    basketListNew = JSON.stringify(basketListNew)
   
    sessionStorage.setItem("basket", basketListNew )
    onLoad();
}
const makeOrder =async () => {
    if (localStorage.getItem("User") == null) {
        window.location.href = "./LoginRegister.html"
    }
       
    else {
        const order = {
            orderSum: allPrice,
            UserId: JSON.parse(localStorage.getItem("User")).userId,
            orderDate: new Date(),
            orderItems: JSON.parse(sessionStorage.getItem("basket"))
        }
        if (order.orderItems.length == 0) {
            alert("Cant create empty order")
            window.location.href = "./products.html"
        }
            
        else {
             try {
                 const res = await fetch("../api/Order", {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(order)

                })
                if (!res.ok)
                    throw new Error("problem")
                else {
                    const orderNum = await res.json()
                    const token=123456
                    alert("Your order created sucessfully your order num is:" + (orderNum.orderId+token))
                    sessionStorage.removeItem("basket")
                    localStorage.removeItem("User")
                    window.location.href = "./products.html"
                }
            }
            catch (ex) {
                alert("order didnt worked")
            }
        }
           
            
            
        }
        
}