
function getdata(){
    const xhttp=new XMLHttpRequest();
    xhttp.open("GET","products.json",true);
    xhttp.onreadystatechange=function(){
        if(this.status==200 && this.readyState==4){
            let data_store=JSON.parse(this.responseText);
            let data=localStorage.getItem("data");
            if(data==null || data==""){
            //    alert("hello")
                localStorage.setItem("data",JSON.stringify(data_store));
                 createCards();
            }
            else{
                 createCards();
            }
        }
    }
    xhttp.send();
}
getdata();


function createCards(){
    let store=JSON.parse(localStorage.getItem("data")); 
    let text=""  ;
    for(let i=0;i<store.length;i++){
        text=text+`<div class="col-sm-4 mb-3" id="cartdata">
                        <div class="card h-70">
                            <div class="card-body">
                               <img src="${store[i].image}" alt="image" class="card-img-top" height=300px>
                                <h5 class="card-title">${store[i].name}</h5>
                                <p class="card-text">${store[i].price}</p>
                                <h6 class="card-text">${store[i].description}</h6>
                            </div>
                            <div class="card-footer">
                                <button type="button" class="btn btn-primary" onclick="details(${store[i].id})">Buy Now</button>
                            </div>
                        </div>
                    </div>`;
    }
    document.getElementById("addcarddata").innerHTML=text;
    $("#shopping-cart").hide();
    $("#home").click(function(){
        $("#addcarddata").show();
        $("#shopping-cart").hide();
    })
    $("#cart").click(function(){
        $("#addcarddata").hide();
        $("#shopping-cart").show();
    })
}



function details(detailindex){
$("#detailModal").modal('show');
let store=JSON.parse(localStorage.getItem("data"));
let index=detailindex;
function findindex(){
    for(let i=0;i<store.length;i++){
        if(index==store[i].id){
            return i;
        }
    }
}
var x=findindex();
// debugger;
var img=store[x].image;
var name=store[x].name;
var price=store[x].price;
var description=store[x].description;
document.getElementById("detail_image").src=img;
document.getElementById("detail_name").value=name;
document.getElementById("detail_price").value=price;
document.getElementById("detail_description").value=description;

localStorage.setItem("data",JSON.stringify(store));
document.getElementById("cartdata").innerHTML="";
createCards();
}

function addSomething(){
    let store=JSON.parse(localStorage.getItem("data"));
    let newid=(store.length)+1;
    var newname=document.getElementById("add_name").value;
    var newprice=document.getElementById("add_price").value;
    var newdescription=document.getElementById("add_description").value;
    var newimage=document.getElementById("add_image").src;
    if(newname==""||newprice==""||newdescription==""||newimage==""){
        validform();
        return ;
    }
    else{
    var newObj={
        id:newid,
        name:newname,
        price:newprice,
        description:newdescription,
        image:newimage
    }
    store.push(newObj);
    $("#myModal").modal('hide');
    document.getElementById("add_name").value="";
    document.getElementById("add_price").value="";
    document.getElementById("add_description").value="";
    // document.getElementById("add_image").src="";
    localStorage.setItem("data",JSON.stringify(store));
    createCards();
}
alert("Product has successfully added")
}

// /*Image Rendering */
function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#add_image')
                .attr('src', e.target.result)
        };
        reader.readAsDataURL(input.files[0]);
    }
  }

  function addToCart(detailindex){
    // debugger;
    let store=JSON.parse(localStorage.getItem("data"));
    var newname=document.getElementById("detail_name").value;
    var newprice=document.getElementById("detail_price").value;
    var newquanity=document.getElementById("detail_quantity").value;

    var newObj = {
        name: newname,
        price: newprice,
        quantity: newquanity,
        total: newprice
      };
      
    
  var cartArray = new Array();
  if (localStorage.getItem("hello")) {
    cartArray = JSON.parse(localStorage.getItem("hello"));
  }
    
  cartArray.push(JSON.stringify(newObj));

  var cartJSON = JSON.stringify(cartArray);
  localStorage.setItem("hello", cartJSON);
    addToTable();
}


function addToTable() {
    let store2 = JSON.parse(localStorage.getItem("hello"));
    
    let text = "";
    text += `<button type="button" class="btn btn-danger" onclick="emptyCart()">Empty Cart</button>
    <table class=" table tbl-cart" cellpadding="20" id="tabledata">
          <thead class="bg-primary">
              <tr>
                  <th>Name</th>
                  <th>Price</th>
                  <th>Quantity</th>
                  <th>Total</th>
              </tr>
          </thead>`;
    for (let i = 0; i < store2.length; i++) {
      let item = JSON.parse(store2[i]);
      text += `<tbody id="tablebody"><tr>
      <td>${item.name}</td>
      <td>${item.price}</td>
      <td><button class="btn btn-success btn-sm"><i class="bi bi-file-minus"></i>
      </button>${item.quantity}<button class="btn btn-success btn-sm"><i class="bi bi-file-plus"></i></button></td>
      <td>${item.total*item.quantity}</td>
      </tr>`;
    }
    let grandtotal = 0;
    for(let i=0; i<store2.length; i++){
      let item = JSON.parse(store2[i]);
      grandtotal += item.total*item.quantity;
    }
    text += `</tbody><tr id="clc"><th colspan="2">Grand Total</th><th></th><th>${grandtotal}</tr>
    </table><button type="button" class="btn btn-success" onclick="checkout()">checkOut</button>`;
    document.getElementById("hellodata").innerHTML = text;
    
  }
  
function checkout(){
    let store2 = JSON.parse(localStorage.getItem("hello"));
    alert("Your Order has successfully been placed");
    localStorage.removeItem("hello");
     $("#tabledata").hide();
     $("#clc").hide();
  }
  
  function emptyCart(){
    localStorage.removeItem("hello");
    $("#tabledata").hide();
    $("#clc").hide();
  }
  
 function validform(){
    $("#addform").validate({
        rule: {
            name: "required"
        }
    });
 }


