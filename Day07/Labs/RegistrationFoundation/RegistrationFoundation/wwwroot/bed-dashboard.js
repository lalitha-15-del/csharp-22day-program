let beds = [
    { bedNumber: 1, isOccupied: false },
    { bedNumber: 2, isOccupied: true },
    { bedNumber: 3, isOccupied: false },
    { bedNumber: 4, isOccupied: true },
    { bedNumber: 5, isOccupied: false },
    { bedNumber: 6, isOccupied: false },
    { bedNumber: 7, isOccupied: true },
    { bedNumber: 8, isOccupied: false },
    { bedNumber: 9, isOccupied: true },
    { bedNumber: 10, isOccupied: false },
    { bedNumber: 11, isOccupied: false },
    { bedNumber: 12, isOccupied: true }
];


// -----------------------------
// FUNCTION: Render beds on screen
// -----------------------------
function renderBeds() {

    let container = document.getElementById("bedContainer");

    // Clear existing beds
    container.innerHTML = "";

    // Loop through all beds
    for (let i = 0; i < beds.length; i++) {

        let bed = beds[i];

        // Create a div for each bed
        let bedDiv = document.createElement("div");

        // Assign common bed class
        bedDiv.classList.add("bed");

        // Condition to decide color
        if (bed.isOccupied) {
            bedDiv.classList.add("occupied");
            bedDiv.innerText = "Bed " + bed.bedNumber + "\nOccupied";
        } else {
            bedDiv.classList.add("available");
            bedDiv.innerText = "Bed " + bed.bedNumber + "\nAvailable";
        }

        // Click event to toggle bed status
        bedDiv.onclick = function () {
            bed.isOccupied = !bed.isAvailable;
            renderBeds(); // Re-render UI
        };
        count();
        // Add bed to container
        container.appendChild(bedDiv);
    }
}
function count() {
    let total = 12;
    let occupied = 0;
    for (let i = 0; i < beds.length; i++) {
        if (beds[i].isOccupied)
            occupied++;
    }
    document.getElementById("bedCount").innerText =
        `Total Beds: ${total} | Occupied: ${occupied}`;

}


// -----------------------------
// INITIAL LOAD
// -----------------------------
renderBeds();
count();
