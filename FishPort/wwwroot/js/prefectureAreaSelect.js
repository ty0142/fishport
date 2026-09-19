function changeAreaList(prefectureId) {
    const filteredAreas = areas.filter(area =>
        area.PrefectureId == prefectureId
    );

    areaSelect.innerHTML = "";

    filteredAreas.forEach(area => {
        const option = document.createElement("option");
        option.value = area.Id;
        option.textContent = area.AreaName;
        if (area.Id == currentAreaId) {
            option.selected = true;
        }       
        areaSelect.appendChild(option);
    });
}
prefectureSelect.addEventListener("change", function () {
    changeAreaList(this.value);
});

if (currentAreaId != null) {
    changeAreaList(prefectureSelect.value);
}