function changeAreaList(PrefectionId) {
    const filteredAreas = areas.filter(area =>
        area.PrefectureId == prefectureId
    );

    areaSelect.innerHTML = "";

    filteredAreas.forEach(area => {
        const option = document.createElement("option");
        option.value = area.Id;
        option.textContent = area.AreaName;
        areaSelect.appendChild(option);
    });

}