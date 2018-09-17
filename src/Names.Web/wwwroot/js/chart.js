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
            datasets: [],
            labels: [1920, 1930, 1940, 1950, 1960, 1970, 1980, 1990, 2000, 2010]
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

    window.chartFunctions = {
        renderChart: function() {
            var ctx = document.getElementById('canvas').getContext('2d');
            nameChart = new Chart(ctx, config);

            // Add this
            var script = document.createElement('script');
            script.src = '//s7.addthis.com/js/300/addthis_widget.js#pubid=ra-5afefe6e3de26255';
            document.body.appendChild(script);

            return true;
        },
        addDataset: function(id, name, data) {
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
        },
        removeDataset: function(id) {
            var index = nameChart.data.datasets.findIndex(function(element) {
                return element.id === id;
            });
            nameChart.data.datasets.splice(index, 1);
            nameChart.update();

            return true;
        },
        replaceDataset: function(id, data) {
            var index = nameChart.data.datasets.findIndex(function(element) {
                return element.id === id;
            });
            nameChart.data.datasets[index].data = data;
            nameChart.update();

            return true;
        },
        removeAllDatasets: function() {
            nameChart.data.datasets = [];
            nameChart.update();

            return true;
        }
    };
})();
