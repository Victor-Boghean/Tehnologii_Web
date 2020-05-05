function onButtonClick(){
  document.getElementById('textInput').className="show";
  $(document).on("keypress", "input", function(e){
        if(e.which == 13){
            var inputVal = $(this).val();
            alert("Ai schimat pretul: " + inputVal);
            location.reload(true);
        }
    });
}
