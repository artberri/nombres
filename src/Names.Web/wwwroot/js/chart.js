(function() {
    'use strict';

    var nameChart, colorCount = 0;

    var chartColors = [
        'rgb(255, 99, 132)', // red
        'rgb(255, 159, 64)', // orange
        'rgb(255, 205, 86)', // yellow
        'rgb(75, 192, 192)', // green
        'rgb(54, 162, 235)', // blue
        'rgb(153, 102, 255)', // purple
        'rgb(201, 203, 207)' // grey
    ];

    var config = {
        type: 'line',
        data: {
            datasets: []
        },
        options: {
            responsive: true,
            title: {
                display: true,
                text: 'Frecuencia de nombres por década'
            },
            tooltips: {
                mode: 'index',
                intersect: false,
            },
            hover: {
                mode: 'nearest',
                intersect: true
            },
            scales: {
                xAxes: [{
                    display: true,
                    scaleLabel: {
                        display: true,
                        labelString: 'Década'
                    }
                }],
                yAxes: [{
                    display: true,
                    scaleLabel: {
                        display: true,
                        labelString: 'Cantidad'
                    },
                    ticks: {
                        min: 0
                    }
                }]
            }
        }
    };

    Blazor.registerFunction('renderChart', function(decades) {
        config.data.labels = decades;

        var ctx = document.getElementById('canvas').getContext('2d');
        nameChart = new Chart(ctx, config);

        return true;
    });

    Blazor.registerFunction('addDataset', function(id, name, data) {
        var colorIndex = colorCount % 7;
        colorCount++;
        nameChart.data.datasets.push({
            id: id,
            label: name,
            backgroundColor: chartColors[colorIndex],
            borderColor: chartColors[colorIndex],
            data: data,
            fill: false,
        });
        nameChart.update();

        return true;
    });

    Blazor.registerFunction('removeDataset', function(id) {
        var index = nameChart.data.datasets.findIndex(function(element) {
            return element.id === id;
        });
        nameChart.data.datasets.splice(index, 1);
        nameChart.update();

        return true;
    });
})();
