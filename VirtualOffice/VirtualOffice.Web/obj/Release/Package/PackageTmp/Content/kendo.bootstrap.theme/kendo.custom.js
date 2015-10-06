// Kendo UI theme for data visualization widgets
// Use as theme: 'newTheme' in configuration options (or change the name)
kendo.dataviz.ui.registerTheme('newTheme', {
    "chart": {
        "title": {
            "color": "#333333"
        },
        "legend": {
            "labels": {
                "color": "#333333"
            }
        },
        "chartArea": {
            "background": "#ffffff"
        },
        "seriesDefaults": {
            "labels": {
                "color": "#333333"
            }
        },
        "axisDefaults": {
            "line": {
                "color": "#cccccc"
            },
            "labels": {
                "color": "#333333"
            },
            "minorGridLines": {
                "color": "#ebebeb"
            },
            "majorGridLines": {
                "color": "#cccccc"
            },
            "title": {
                "color": "#333333"
            }
        },
        "seriesColors": [
            "#428bca",
            "#5bc0de",
            "#5cb85c",
            "#f2b661",
            "#e67d4a",
            "#da3b36"
        ],
        "tooltip": {}
    },
    "gauge": {
        "pointer": {
            "color": "#428bca"
        },
        "scale": {
            "rangePlaceholderColor": "#cccccc",
            "labels": {
                "color": "#333333"
            },
            "minorTicks": {
                "color": "#ebebeb"
            },
            "majorTicks": {
                "color": "#cccccc"
            },
            "line": {
                "color": "#cccccc"
            }
        }
    }
});