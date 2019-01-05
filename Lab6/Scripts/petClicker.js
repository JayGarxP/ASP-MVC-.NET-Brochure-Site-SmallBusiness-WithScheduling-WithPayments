// JavaScript source code
//<script src="/scripts/Script.js"></script>
var speciesID = -1;

function clickPet(speciesID) {
    document.getElementById("petClickedID").value = speciesID
    if (speciesID == 0) {
        document.getElementById("kindness").innerHTML = "BUYING KINDNESS FOR 100"
        document.getElementById("health").innerHTML = "Health..."
        document.getElementById("success").innerHTML = "Success..."
    } else if (speciesID == 1) {
        document.getElementById("health").innerHTML = "BUYING HEALTH FOR 100"
        document.getElementById("success").innerHTML = "Success..."
        document.getElementById("kindness").innerHTML = "Kindness..."   
    } else if (speciesID == 2) {
        document.getElementById("success").innerHTML = "BUYING SUCCESS FOR 100"
        document.getElementById("kindness").innerHTML = "Kindness..."
        document.getElementById("health").innerHTML = "Health..."
    }
    
    
}
