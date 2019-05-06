//function confirmDelete(id) {
//    let res = confirm("Are you sure?");
//    if (res) {
//        var url = window.location.pathname.split("/");
//        var currentController = url[1];    
//        location.href = `/${currentController}/delete/${id}`;
//    }
//}

function confirmDelete(id) {
    let res = confirm("Are you sure?");
    if (res) {
                var url = window.location.pathname.split("/");
                var currentController = url[1];
                $.ajax({
                    url: `${currentController}/delete/${id}`,
                    type: "GET",
                    success: function (res) {
                        if(res){
                            $(`#${id}`).remove();
                        }
                    },
                    error:function(err){
                        console.log(err);
                }
                })
    }
}