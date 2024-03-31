// Sample ship data for Oman's coastal area
const shipData = [
    { lat: 23.6104, lng: 58.5905, intensity: 5 },
    { lat: 23.6289, lng: 58.5401, intensity: 7 },
    { lat: 23.5454, lng: 58.5117, intensity: 3 },
    { lat: 23.5056, lng: 58.5606, intensity: 2 },
    { lat: 23.4346, lng: 58.4869, intensity: 4 },
    { lat: 23.3985, lng: 58.4394, intensity: 6 },
    { lat: 23.3334, lng: 58.4167, intensity: 8 },
    // Add more data points along Oman's coastline
];

// Create a map centered at specific coordinates (Oman)
const map = L.map('map').setView([23.6104, 58.5905], 5);

// Add a tile layer to the map (OpenStreetMap)
L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
    attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
}).addTo(map);

// Define a function to create a heatmap layer
function createHeatmapLayer(data) {
    const heatMapData = data.map(point => [point.lat, point.lng, point.intensity]);
    const heat = L.heatLayer(heatMapData, {
        radius: 25,
        gradient: {
            0.1: 'yellow', // Yellow for density between 1 and 3
            0.5: 'orange', // Orange for density between 4 and 6
            0.8: 'red' // Red for density between 7 and 10
        }
    }).addTo(map);

    // Fit the map to the bounds of the heatmap data
    map.fitBounds(heat.getBounds());
}

// Call the function to create the heatmap layer with ship data
createHeatmapLayer(shipData);