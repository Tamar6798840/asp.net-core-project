

const showProducts = async (url) => {
    let min = 1000;
    let max = 0;
    const divproducts = document.getElementById("ProductList")
    divproducts.replaceChildren([]);
    let productList = await getProducts(url);
    
        for ( let i = 0; i < productList.length; i++)
            {
            drawProduct(productList[i])
            if (productList[i].price > max)
                max = productList[i].price
            if (productList[i].price < min)
                min = productList[i].price
            }
    document.getElementById("minPrice").placeholder = min;
    document.getElementById("maxPrice").placeholder = max;
   
    

}
const showCategories = async () => {
    let categorytList = await getCategory();
        for (let i = 0; i < categorytList.length; i++) {
    drawCategory(categorytList[i])
    }
}
const onLoad = () => {
    showCategories()
    showProducts("")
    if (sessionStorage.getItem("basket") == null) {
        sessionStorage.setItem("basket", "[]");
    }
    else {
        document.getElementById("ItemsCountText").innerText = JSON.parse(sessionStorage.getItem("basket")).length;
    }
}
const getProducts = async (url) => { 
    try {
        const res = await fetch(`../api/Products`+url)
        if (!res.ok) throw new Error("No-products!!!")
        const data = await res.json()
        document.getElementById("counter").innerText = data.length
        return (data)
     
    }
    catch (ex) {
        console.log(ex);
    }
}
const getCategory = async () => {
    try {
        const res = await fetch(`../api/Category`)
        if (!res.ok) throw new Error("There is no category")
      return (await res.json())

    }
    catch (ex) {
        console.log(ex);
    }
}
const drawCategory = (category) => {
    const categoryList = document.getElementById("categoryList")
    const template = document.getElementById("temp-category").content;
    const clone = template.cloneNode(true);
    const categoryName = clone.querySelector(".opt");
    clone.querySelector("span.OptionName").innerText = category.categoryName
    categoryName.value = category.categoryName
    categoryName.id = category.categoryId;
    categoryList.appendChild(clone);
    categoryName.addEventListener('click', () => filter() );
    
}
const drawProduct = (product) => {
  
    const template = document.getElementById("temp-card").content;
    const productsList = document.getElementById("ProductList")
    const clone = template.cloneNode(true);
    const image = clone.querySelector("img");
    const h1 = clone.querySelector("h1");
    const price = clone.querySelector(".price");
    const description = clone.querySelector(".description");
    const button = clone.querySelector("button");

    image.src = "../pictures/products/" + product.image + ".png";
    h1.textContent = product.prodName;
    price.textContent = product.price + "$";
    description.textContent = product.description;
    button.addEventListener('click', () => { addToCart(product) });
  

    productsList.appendChild(clone);


}
const addToCart = (product) => {
    document.getElementById("ItemsCountText").innerText++;
    let basketList = sessionStorage.getItem("basket");
    if (basketList != "[]") { 
        basketList = JSON.parse(basketList)
        let toSessionStorage=[...basketList,product]
        sessionStorage.setItem("basket", JSON.stringify(toSessionStorage));}
    else {
    sessionStorage.setItem("basket", JSON.stringify([product]));
    }
    
}
const filter = () => {
    let categories = [];
    let url='';
    const categoryList = document.querySelectorAll(".opt")
    categoryList.forEach(cat => {
        if (cat.checked)
            categories.push(cat.id)
    })
    let desc = document.getElementById("nameSearch").value
    let minPrice = document.getElementById("minPrice").value
    let maxPrice = document.getElementById("maxPrice").value

    if (desc != '' || minPrice > 0 || maxPrice > minPrice || categories!=null) {
        url += '?'
    }
    if (desc != '') {
        url += `&desc=${desc}`
    }
    if (minPrice > 0) {
        url += `&minPrice=${minPrice}`
    }
    if (maxPrice > minPrice) {
        url += `&maxPrice=${maxPrice}`
    }
    for (let i = 0; i < categories.length; i++) {
        url = url + `&categoryIds=${categories[i]}`
    }
    showProducts(url)


    }
