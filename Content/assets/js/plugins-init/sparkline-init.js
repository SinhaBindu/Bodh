!function(t){"use strict";function r(r){var e=t(window).width(),a="100%";return e<=768&&(e=e<300?e:300,r=jQuery(r).parent().innerWidth()-jQuery(r).parent().width(),a=e-(r=Math.abs(r))-10),a}0<jQuery("#sparklinedash").length&&t("#sparklinedash").sparkline([10,15,26,27,28,31,34,40,41,44,49,64,68,69,72],{type:"bar",height:"50",barWidth:"4",resize:!0,barSpacing:"5",barColor:"#222fb9"}),0<jQuery("#sparkline8").length&&t("#sparkline8").sparkline([79,72,29,6,52,32,73,40,14,75,77,39,9,15,10],{type:"line",width:r("#sparkline8"),height:"50",lineColor:"#222fb9",fillColor:"rgba(34, 47, 185, .5)",minSpotColor:"#222fb9",maxSpotColor:"#222fb9",highlightLineColor:"#222fb9",highlightSpotColor:"#222fb9"}),0<jQuery("#sparkline9").length&&t("#sparkline9").sparkline([27,31,35,28,45,52,24,4,50,11,54,49,72,59,75],{type:"line",width:r("#sparkline9"),height:"50",lineColor:"#ffe600",fillColor:"rgba(255, 230, 1, .5)",minSpotColor:"#ffe600",maxSpotColor:"#ffe600",highlightLineColor:"rgb(255, 230, 1)",highlightSpotColor:"#ffe600"}),0<jQuery("#spark-bar").length&&t("#spark-bar").sparkline([33,22,68,54,8,30,74,7,36,5,41,19,43,29,38],{type:"bar",height:"200",barWidth:6,barSpacing:7,barColor:"#21b731"}),0<jQuery("#spark-bar-2").length&&t("#spark-bar-2").sparkline([33,22,68,54,8,30,74,7,36,5,41,19,43,29,38],{type:"bar",height:"140",width:100,barWidth:10,barSpacing:10,barColor:"rgb(255, 206, 120)"}),0<jQuery("#StackedBarChart").length&&t("#StackedBarChart").sparkline([[1,4,2],[2,3,2],[3,2,2],[4,1,2]],{type:"bar",height:"200",barWidth:10,barSpacing:7,stackedBarColor:["#222fb9","#21b731","#ff7a01"]}),0<jQuery("#tristate").length&&t("#tristate").sparkline([1,1,0,1,-1,-1,1,-1,0,0,1,1],{type:"tristate",height:"200",barWidth:10,barSpacing:7,colorMap:["#222fb9","#21b731","#ff7a01"],negBarColor:"#ff7a01"}),0<jQuery("#composite-bar").length&&t("#composite-bar").sparkline([73,53,50,67,3,56,19,59,37,32,40,26,71,19,4,53,55,31,37],{type:"bar",height:"200",barWidth:"10",resize:!0,barColor:"#222fb9",width:"100%"}),0<jQuery("#sparkline-composite-chart").length&&t("#sparkline-composite-chart").sparkline([5,6,7,2,0,3,6,8,1,2,2,0,3,6],{type:"line",width:"100%",height:"200",barColor:"#21b731",colorMap:["#21b731","#ff7a01"]}),0<jQuery("#sparkline-composite-chart").length&&t("#sparkline-composite-chart").sparkline([5,6,7,2,0,3,6,8,1,2,2,0,3,6],{type:"bar",height:"150px",width:"100%",barWidth:10,barSpacing:5,barColor:"#34C73B",negBarColor:"#34C73B",composite:!0}),0<jQuery("#sparkline11").length&&t("#sparkline11").sparkline([24,61,51],{type:"pie",height:"100px",resize:!0,sliceColors:["rgba(192, 10, 39, .5)","rgba(0, 0, 128, .5)","rgba(69, 11, 90, .5)"]}),0<jQuery("#sparkline12").length&&t("#sparkline12").sparkline([24,61,51],{type:"pie",height:"100",resize:!0,sliceColors:["rgba(179, 204, 255, 1)","rgba(157, 189, 255, 1)","rgba(112, 153, 237, 1)"]}),0<jQuery("#bullet-chart").length&&t("#bullet-chart").sparkline([10,12,12,9,7],{type:"bullet",height:"100",width:"100%",targetOptions:{width:"100%",height:3,borderWidth:0,borderColor:"black",color:"black"}}),0<jQuery("#boxplot").length&&t("#boxplot").sparkline([4,27,34,52,54,59,61,68,78,82,85,87,91,93,100],{type:"box"})}(jQuery);