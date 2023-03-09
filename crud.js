var xhttp = new XMLHttpRequest();
xhttp.open("GET","https://jsonplaceholder.typicode.com/todos", true);
xhttp.onreadystatechange=function (){
    if (this.status == 200 && this.readyState == 4){
        let data = JSON.parse(xhttp.responseText);
        let local=localStorage.getItem('name');
        if(local==null || local==""){
            localStorage.setItem('name', JSON.stringify(data));
            createTable();
        }
        else{
            createTable();
        }    
    }
}
xhttp.send();

function valid(){
    // debugger;
    $("#myForm").validate({  
        rules:{
            // uid:"required",
            // title: "required",
            // completed: "required"
        },
        // messages:{
        //     uid: "required",
        //     title: "required",
        //     completed: "required"

        // },
        // submitHandler: function(form) {  
        //     form.submit(); 
        // }
    });
    $("#updateData").validate({
        
    })
     
}

function newData(){
    $("#modal").modal('show');
}

function deleteData(index){
    $("#modalDelete").modal('show');
    let currData = JSON.parse(localStorage.getItem('name'));
    var deleteindex=index;
    function deleteRow(){
        for(let i=0;i<currData.length;i++){
            if(deleteindex==currData[i].id){
                return i;
            }
        }
    }
    var x=deleteRow();
    $("#delRow").click(function(){
        currData.splice(x,1);
        for(let i=x; i<currData.length; i++){
            currData[i].id = deleteindex;
            deleteindex++;
        }
        localStorage.setItem("name",JSON.stringify(currData));
        document.getElementById("myTable").innerHTML="";
        createTable();
    })

}

function updateData(editindex){
    $('#modalEdit').modal('show');

    let currData=JSON.parse(localStorage.getItem("name"));
    let index=editindex;
    function findIndex(){
        for(let i=0;i<currData.length;i++){
            if(index==currData[i].id){
               return i;
            }
        }
    }
    var x= findIndex();
    var uid=currData[x].userId;
    var title=currData[x].title;
    var completed = currData[x].completed;
    document.getElementById("eUId").value=uid;
    document.getElementById("eTitle").value=title;
    document.getElementById("eCompleted").value=completed;

    $("#editRow").click(function(){
        var cUid = $("#eUId").val();
        var cTitle = $("#eTitle").val();
        var cCompleted = $("#eCompleted").val();

        if (cUid==""||cTitle==""||cCompleted==""){
            valid();
            
        }

        else{
            $("#modalEdit").modal('hide');
            var new_uid=document.getElementById("eUId").value;
            var new_title=document.getElementById("eTitle").value;
            var new_completed=document.getElementById("eCompleted").value;
            currData[x].uid=new_uid;
            currData[x].title=new_title;
            currData[x].completed=new_completed;
            
            localStorage.setItem("name",JSON.stringify(currData));
            document.getElementById("myTable").innerHTML="";
            createTable();
        }
    });
    
}


function saveData(){

    let currData = JSON.parse(localStorage.getItem('name'));
    var uid = $("#uid").val();
    var id = currData[currData.length-1].id + 1;
    var title = $("#title").val();
    var completed = $("#completed").val();

    if(uid=="" || title=="" || completed==""){
        valid();
    }
    
    else
    {
        var obj = {
            userId: uid,
            id: id,
            title : title,
            completed: completed,
        };
        $("#modal").modal('hide');
        currData.push(obj);
       $("#inputDataDiv").val("")
       localStorage.setItem('name',JSON.stringify(currData));
       document.getElementById("myTable").innerHTML="";
       createTable(currData);
    }

}


function createTable(){

    let currData=JSON.parse(localStorage.getItem('name'));
    let table="";
    table = `<table id="showData"><thead><tr>
            <th>UserId</th>
            <th>Id</th>
            <th>Title</th>
            <th>Completed</th>
            <th></th>
            <th></th>
            </tr></thead><tbody>`;

            for (let i=0; i<currData.length/2; i++){
                table += `<tr id="${currData[i].userId}">
                <td>${currData[i].userId}</td>
                <td>${currData[i].id}</td>
                <td>${currData[i].title}</td>
                <td>${currData[i].completed}</td>
                <td>${`<input type="button" class="btn btn-outline-primary" value="Update" onclick="updateData(${currData[i].id})">`}</td>
                <td>${`<input type="button" class="btn btn-outline-danger" value="Delete" onclick="deleteData(${currData[i].id}, this)">`}</td>
                </tr>`
            }
            table=table+`</tbody></table>`
            localStorage.setItem('name',JSON.stringify(currData));
            document.getElementById("myTable").innerHTML = table;
            $("#showData").DataTable();
}








