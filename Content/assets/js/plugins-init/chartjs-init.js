!function(I){var e=function(){I(window).width();return{init:function(){},load:function(){var t,a,e,r,o,n,d,s,i,l,c,g,u,b,p,h,y,C,m,f,k;if(0<jQuery("#barChart_1").length&&((e=document.getElementById("barChart_1").getContext("2d")).height=100,(r=Chart.getChart(e.canvas.id))&&r.destroy(),t={type:"bar",data:{defaultFontFamily:"Poppins",labels:["Jan","Feb","Mar","Apr","May","Jun","Jul"],datasets:[{label:"My First dataset",data:[65,59,80,81,56,55,40],borderColor:"rgba(34, 47, 185, 1)",borderWidth:"0",backgroundColor:"rgba(34, 47, 185, 1)",barThickness:"30"}]},options:{plugins:{legend:!1},barPercentage:.5,scales:{y:{beginAtZero:!0}}}},a=new Chart(e,t),r=document.querySelector("body"),new MutationObserver(function(e){e.forEach(function(e){"data-theme-version"===e.attributeName&&("dark"===I("body").attr("data-theme-version")?(t.options.scales.y.grid.color="#3d3d4e",t.options.scales.x.grid.color="#3d3d4e"):(t.options.scales.y.grid.color="#eee",t.options.scales.x.grid.color="#eee"),a.update())})}).observe(r,{attributes:!0})),0<jQuery("#barChart_2").length&&((r=(e=document.getElementById("barChart_2").getContext("2d")).createLinearGradient(0,0,0,250)).addColorStop(0,"rgba(34, 47, 185, 1)"),r.addColorStop(1,"rgba(34, 47, 185, 0.5)"),e.height=100,(d=Chart.getChart(e.canvas.id))&&d.destroy(),o={type:"bar",data:{defaultFontFamily:"Poppins",labels:["Jan","Feb","Mar","Apr","May","Jun","Jul"],datasets:[{label:"My First dataset",data:[65,59,80,81,56,55,40],borderColor:r,borderWidth:"0",backgroundColor:r,hoverBackgroundColor:r}]},options:{plugins:{legend:!1},barPercentage:.5,scales:{y:{ticks:{beginAtZero:!0}}}}},n=new Chart(e,o),d=document.querySelector("body"),new MutationObserver(function(e){e.forEach(function(e){"data-theme-version"===e.attributeName&&("dark"===I("body").attr("data-theme-version")?(o.options.scales.y.grid.color="#3d3d4e",o.options.scales.x.grid.color="#3d3d4e"):(o.options.scales.y.grid.color="#eee",o.options.scales.x.grid.color="#eee"),n.update())})}).observe(d,{attributes:!0})),0<jQuery("#barChart_3").length&&((v=(d=document.getElementById("barChart_3").getContext("2d")).createLinearGradient(50,100,50,50)).addColorStop(0,"rgba(34, 47, 185, 1)"),v.addColorStop(1,"rgba(34, 47, 185, 0.5)"),(w=d.createLinearGradient(50,100,50,50)).addColorStop(0,"rgba(33, 183, 49, 1)"),w.addColorStop(1,"rgba(33, 183, 49, 1)"),(M=d.createLinearGradient(50,100,50,50)).addColorStop(0,"rgba(255, 38, 37, 1)"),M.addColorStop(1,"rgba(255, 38, 37, 1)"),(S=Chart.getChart(d.canvas.id))&&S.destroy(),s={type:"bar",data:{defaultFontFamily:"Poppins",labels:["Mon","Tue","Wed","Thur","Fri","Sat","Sun"],datasets:[{label:"Red",backgroundColor:v,hoverBackgroundColor:v,data:["12","12","12","12","12","12","12"]},{label:"Green",backgroundColor:w,hoverBackgroundColor:w,data:["12","12","12","12","12","12","12"]},{label:"Blue",backgroundColor:M,hoverBackgroundColor:M,data:["12","12","12","12","12","12","12"]}]},options:{plugins:{legend:{display:!(d.height=100)},title:{display:!1},tooltip:{mode:"index",intersect:!1}},responsive:!0,scales:{x:{stacked:!0},y:{stacked:!0}}}},i=new Chart(d,s),S=document.querySelector("body"),new MutationObserver(function(e){e.forEach(function(e){"data-theme-version"===e.attributeName&&("dark"===I("body").attr("data-theme-version")?(s.options.scales.y.grid.color="#3d3d4e",s.options.scales.x.grid.color="#3d3d4e"):(s.options.scales.y.grid.color="#eee",s.options.scales.x.grid.color="#eee"),i.update())})}).observe(S,{attributes:!0})),0<jQuery("#lineChart_1").length){var v=document.getElementById("lineChart_1").getContext("2d");class W extends Chart.LineController{draw(){super.draw(arguments);const e=this.chart.ctx;let t=e.stroke;e.stroke=function(){e.save(),e.shadowColor="rgba(59, 76, 184, .2)",e.shadowBlur=10,e.shadowOffsetX=0,e.shadowOffsetY=10,t.apply(this,arguments),e.restore()}}}W.id="shadowLine",W.defaults=Chart.LineController.defaults,Chart.register(W);var w=Chart.getChart(v.canvas.id),x=(w&&w.destroy(),{type:"shadowLine",data:{defaultFontFamily:"Poppins",labels:["Jan","Febr","Mar","Apr","May","Jun","Jul"],datasets:[{label:"My First dataset",data:[25,20,60,41,66,45,80],borderColor:"rgba(34, 47, 185, 1)",borderWidth:"2",backgroundColor:"transparent",pointBackgroundColor:"rgba(34, 47, 185, 1)",tension:.5}]},options:{plugins:{legend:!(v.height=100)},scales:{y:{min:0,ticks:{beginAtZero:!0,stepSize:20,padding:10}},x:{ticks:{padding:5}}}}}),F=new Chart(v,x),w=document.querySelector("body");new MutationObserver(function(e){e.forEach(function(e){"data-theme-version"===e.attributeName&&("dark"===I("body").attr("data-theme-version")?(x.options.scales.y.grid.color="#3d3d4e",x.options.scales.x.grid.color="#3d3d4e"):(x.options.scales.y.grid.color="#eee",x.options.scales.x.grid.color="#eee"),F.update())})}).observe(w,{attributes:!0})}if(0<jQuery("#lineChart_2").length){var M=document.getElementById("lineChart_2").getContext("2d"),S=M.createLinearGradient(500,0,100,0);S.addColorStop(0,"rgba(34, 47, 185, 1)"),S.addColorStop(1,"rgba(34, 47, 185, 0.5)");class j extends Chart.LineController{draw(){super.draw(arguments);const e=this.chart.ctx;let t=e.stroke;e.stroke=function(){e.save(),e.shadowColor="rgba(0, 0, 128, .2)",e.shadowBlur=10,e.shadowOffsetX=0,e.shadowOffsetY=10,t.apply(this,arguments),e.restore()}}}j.id="shadowLine",j.defaults=Chart.LineController.defaults,Chart.register(j);var B=Chart.getChart(M.canvas.id),_=(B&&B.destroy(),{type:"shadowLine",data:{defaultFontFamily:"Poppins",labels:["Jan","Feb","Mar","Apr","May","Jun","Jul"],datasets:[{label:"My First dataset",data:[25,20,60,41,66,45,80],borderColor:S,borderWidth:"2",backgroundColor:"transparent",pointBackgroundColor:"rgba(34, 47, 185, 0.5)",tension:.5}]},options:{plugins:{legend:!(M.height=100)},scales:{y:{max:100,min:0,ticks:{stepSize:20,padding:10}},x:{ticks:{padding:5}}}}}),O=new Chart(M,_),B=document.querySelector("body");new MutationObserver(function(e){e.forEach(function(e){"data-theme-version"===e.attributeName&&("dark"===I("body").attr("data-theme-version")?(_.options.scales.y.grid.color="#3d3d4e",_.options.scales.x.grid.color="#3d3d4e"):(_.options.scales.y.grid.color="#eee",_.options.scales.x.grid.color="#eee"),O.update())})}).observe(B,{attributes:!0})}if(0<jQuery("#lineChart_3").length){var B=document.getElementById("lineChart_3").getContext("2d"),J=B.createLinearGradient(500,0,100,0),A=(J.addColorStop(0,"rgba(34, 47, 185, 1)"),J.addColorStop(1,"rgba(34, 47, 185, 0.5)"),B.createLinearGradient(500,0,100,0));A.addColorStop(0,"rgba(255, 92, 0, 1)"),A.addColorStop(1,"rgba(255, 92, 0, 1)");class Q extends Chart.LineController{draw(){super.draw(arguments);const e=this.chart.ctx;let t=e.stroke;e.stroke=function(){e.save(),e.shadowColor="rgba(0, 0, 0, 0)",e.shadowBlur=10,e.shadowOffsetX=0,e.shadowOffsetY=10,t.apply(this,arguments),e.restore()}}}Q.id="shadowLine",Q.defaults=Chart.LineController.defaults,Chart.register(Q);var E=Chart.getChart(B.canvas.id),L=(E&&E.destroy(),{type:"line",data:{defaultFontFamily:"Poppins",labels:["Jan","Feb","Mar","Apr","May","Jun","Jul"],datasets:[{label:"My First dataset",data:[25,20,60,41,66,45,80],borderColor:J,borderWidth:"2",backgroundColor:"transparent",pointBackgroundColor:"rgba(34, 47, 185, 0.5)",tension:.5},{label:"My First dataset",data:[5,20,15,41,35,65,80],borderColor:A,borderWidth:"2",backgroundColor:"transparent",pointBackgroundColor:"rgba(254, 176, 25, 1)",tension:.5}]},options:{plugins:{legend:!(B.height=100)},scales:{y:{max:100,min:0,ticks:{beginAtZero:!0,stepSize:20,padding:10}},x:{ticks:{padding:5}}}}}),P=new Chart(B,L),E=document.querySelector("body");new MutationObserver(function(e){e.forEach(function(e){"data-theme-version"===e.attributeName&&("dark"===I("body").attr("data-theme-version")?(L.options.scales.y.grid.color="#3d3d4e",L.options.scales.x.grid.color="#3d3d4e"):(L.options.scales.y.grid.color="#eee",L.options.scales.x.grid.color="#eee"),P.update())})}).observe(E,{attributes:!0})}0<jQuery("#lineChart_3Kk").length&&(J=document.getElementById("lineChart_3Kk").getContext("2d"),Chart.controllers.line=Chart.controllers.line.extend({draw:function(){draw.apply(this,arguments);let e=this.chart.chart.ctx,t=e.stroke;e.stroke=function(){e.save(),e.shadowColor="rgba(0, 0, 0, 0)",e.shadowBlur=10,e.shadowOffsetX=0,e.shadowOffsetY=10,t.apply(this,arguments),e.restore()}}}),J.height=100,new Chart(J,{type:"line",data:{defaultFontFamily:"Poppins",labels:["Jan","Feb","Mar","Apr","May","Jun","Jul"],datasets:[{label:"My First dataset",data:[90,60,80,50,60,55,80],borderColor:"rgba(58,122,254,1)",borderWidth:"3",backgroundColor:"rgba(0,0,0,0)",pointBackgroundColor:"rgba(0, 0, 0, 0)",tension:.5}]},options:{plugins:{legend:!1},elements:{point:{radius:0}},scales:{yAxes:[{ticks:{beginAtZero:!0,max:100,min:0,stepSize:20,padding:10},borderWidth:3,display:!1,lineTension:.4}],xAxes:[{ticks:{padding:5}}]}}})),0<jQuery("#areaChart_1").length&&(A=document.getElementById("areaChart_1").getContext("2d"),(E=Chart.getChart(A.canvas.id))&&E.destroy(),l={type:"line",data:{defaultFontFamily:"Poppins",labels:["Jan","Feb","Mar","Apr","May","Jun","Jul"],datasets:[{label:"My First dataset",data:[25,20,60,41,66,45,80],borderColor:"rgba(0, 0, 1128, .3)",borderWidth:"1",backgroundColor:"rgba(34, 47, 185, .5)",pointBackgroundColor:"rgba(0, 0, 1128, .3)",tension:.5,fill:!0}]},options:{plugins:{legend:!(A.height=100)},scales:{y:{max:100,min:0,ticks:{beginAtZero:!0,stepSize:20,padding:10}},x:{padding:5}}}},c=new Chart(A,l),E=document.querySelector("body"),new MutationObserver(function(e){e.forEach(function(e){"data-theme-version"===e.attributeName&&("dark"===I("body").attr("data-theme-version")?(l.options.scales.y.grid.color="#3d3d4e",l.options.scales.x.grid.color="#3d3d4e"):(l.options.scales.y.grid.color="#eee",l.options.scales.x.grid.color="#eee"),c.update())})}).observe(E,{attributes:!0})),0<jQuery("#areaChart_2").length&&((b=(y=document.getElementById("areaChart_2").getContext("2d")).createLinearGradient(0,1,0,500)).addColorStop(0,"rgba(255, 38, 37, 0.2)"),b.addColorStop(1,"rgba(255, 38, 37, 0)"),(C=Chart.getChart(y.canvas.id))&&C.destroy(),g={type:"line",data:{defaultFontFamily:"Poppins",labels:["Jan","Feb","Mar","Apr","May","Jun","Jul"],datasets:[{label:"My First dataset",data:[25,20,60,41,66,45,80],borderColor:"#ff2625",borderWidth:"4",backgroundColor:b,tension:.5,fill:!0}]},options:{plugins:{legend:!(y.height=100)},scales:{y:{max:100,min:0,ticks:{beginAtZero:!0,stepSize:20,padding:5}},x:{ticks:{padding:5}}}}},u=new Chart(y,g),C=document.querySelector("body"),new MutationObserver(function(e){e.forEach(function(e){"data-theme-version"===e.attributeName&&("dark"===I("body").attr("data-theme-version")?(g.options.scales.y.grid.color="#3d3d4e",g.options.scales.x.grid.color="#3d3d4e"):(g.options.scales.y.grid.color="#eee",g.options.scales.x.grid.color="#eee"),u.update())})}).observe(C,{attributes:!0})),0<jQuery("#areaChart_3").length&&(b=document.getElementById("areaChart_3").getContext("2d"),(y=Chart.getChart(b.canvas.id))&&y.destroy(),p={type:"line",data:{defaultFontFamily:"Poppins",labels:["Jan","Feb","Mar","Apr","May","Jun","Jul"],datasets:[{label:"My First dataset",data:[25,20,60,41,66,45,80],borderColor:"rgb(34, 47, 185)",borderWidth:"1",backgroundColor:"rgba(34, 47, 185, .5)",tension:.5,fill:!0},{label:"My First dataset",data:[5,25,20,41,36,75,70],borderColor:"rgb(255, 92, 0)",borderWidth:"1",backgroundColor:"rgba(255, 92, 0, .5)",tension:.5,fill:!0}]},options:{plugins:{legend:!(b.height=100)},scales:{y:{max:100,min:0,ticks:{beginAtZero:!0,stepSize:20,padding:10}},x:{ticks:{padding:5}}}}},h=new Chart(b,p),y=document.querySelector("body"),new MutationObserver(function(e){e.forEach(function(e){"data-theme-version"===e.attributeName&&("dark"===I("body").attr("data-theme-version")?(p.options.scales.y.grid.color="#3d3d4e",p.options.scales.x.grid.color="#3d3d4e"):(p.options.scales.y.grid.color="#eee",p.options.scales.x.grid.color="#eee"),h.update())})}).observe(y,{attributes:!0})),0<jQuery("#radar_chart").length&&((k=(C=document.getElementById("radar_chart").getContext("2d")).createLinearGradient(500,0,100,0)).addColorStop(0,"rgba(54, 185, 216, .5)"),k.addColorStop(1,"rgba(75, 255, 162, .5)"),(f=C.createLinearGradient(500,0,100,0)).addColorStop(0,"rgba(68, 0, 235, .5"),f.addColorStop(1,"rgba(68, 236, 245, .5"),(m=Chart.getChart(C.canvas.id))&&m.destroy(),new Chart(C,{type:"radar",data:{defaultFontFamily:"Poppins",labels:[["Eating","Dinner"],["Drinking","Water"],"Sleeping",["Designing","Graphics"],"Coding","Cycling","Running"],datasets:[{label:"My First dataset",data:[65,59,66,45,56,55,40],borderColor:"#f21780",borderWidth:"1",backgroundColor:f},{label:"My Second dataset",data:[28,12,40,19,63,27,87],borderColor:"#f21780",borderWidth:"1",backgroundColor:k}]},options:{plugins:{legend:!1},maintainAspectRatio:!1,scale:{ticks:{beginAtZero:!0}}}})),0<jQuery("#pie_chart").length&&(m=document.getElementById("pie_chart").getContext("2d"),new Chart(m,{type:"pie",data:{defaultFontFamily:"Poppins",datasets:[{data:[45,25,20,10],borderWidth:0,backgroundColor:["rgba(34, 47, 185, .9)","rgba(34, 47, 185, .7)","rgba(34, 47, 185, .5)","rgba(0,0,0,0.07)"],hoverBackgroundColor:["rgba(34, 47, 185, .9)","rgba(34, 47, 185, .7)","rgba(34, 47, 185, .5)","rgba(0,0,0,0.07)"]}],labels:["one","two","three","four"]},options:{responsive:!0,plugins:{legend:!1},aspectRatio:2,maintainAspectRatio:!1}})),0<jQuery("#doughnut_chart").length&&(f=document.getElementById("doughnut_chart").getContext("2d"),new Chart(f,{type:"doughnut",data:{weight:5,defaultFontFamily:"Poppins",datasets:[{data:[45,25,20],borderWidth:3,borderColor:"rgba(255,255,255,1)",backgroundColor:["rgba(34, 47, 185, 1)","rgba(33, 183, 49, 1)","rgba(255, 38, 37, 1)"],hoverBackgroundColor:["rgba(34, 47, 185, 0.9)","rgba(33, 183, 49, .9)","rgba(255, 38, 37, .9)"]}]},options:{weight:1,cutoutPercentage:70,responsive:!0,maintainAspectRatio:!1}})),0<jQuery("#polar_chart").length&&(k=document.getElementById("polar_chart").getContext("2d"),new Chart(k,{type:"polarArea",data:{defaultFontFamily:"Poppins",datasets:[{data:[15,18,9,6,19],borderWidth:0,backgroundColor:["rgba(34, 47, 185, 1)","rgba(33, 183, 49, 1)","rgba(255, 38, 37, 1)","rgba(39, 129, 213, 1)","rgba(255, 92, 0, 1)"]}]},options:{responsive:!0,aspectRatio:1.7,maintainAspectRatio:!1}}))},resize:function(){}}}();jQuery(document).ready(function(){}),jQuery(window).on("load",function(){e.load()}),jQuery(window).on("resize",function(){setTimeout(function(){e.resize()},1e3)})}(jQuery);