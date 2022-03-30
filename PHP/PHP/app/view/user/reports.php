<div class="row">   
        <div class="col-md-6" style="height:450px">
            <canvas id="monthly_expense"></canvas>
        </div>
        <div class="col-md-6" style="height:450px">
            <canvas id="monthly_income_expense"></canvas>
        </div>
        
</div>
<div class="row">
    <div class="col" style="height:450px">
        <canvas id="yearly_income_expense"></canvas>
    </div>
</div>
    
<script>
    let monthly_expense_xValues = <?php echo json_encode($expense_categories); ?>;
    let monthly_expense_yValues = <?php echo json_encode($expense_amounts); ?>;
    var barColors = ["red", "green", "blue", "orange", "brown", "yellow", "purple"];
    new Chart("monthly_expense", {
        type: "pie",
        data: {
            labels: monthly_expense_xValues,
            datasets: [{
            backgroundColor: barColors,
            data: monthly_expense_yValues
            }]
        },
        options: {
            maintainAspectRatio: false,
            title: {
            fontSize: 18,
            display: true,
            text: "Monthly expenses breakdown"
            },
            legend: {
                labels: {
                    fontSize: 16
                }
            }
                  
            
        }
    });



var monthly_income_expense_xValues = ["Income", "Expense"];
var monthly_income_yValues = <?php echo json_encode($income_amounts); ?>;
console.log(monthly_income_yValues);
var barColors2 = ["blue", "red"];

new Chart("monthly_income_expense", {
  type: "bar",
  data: {
    labels: monthly_income_expense_xValues,
    datasets: [{
      backgroundColor: barColors2,
      data: monthly_income_yValues.reverse(),
      barPercentage: 0.6,
    }]
  },
  options: {
        maintainAspectRatio: false,
        title: {
        fontSize: 18,
        display: true,
        text: "Monthly income expense breakdown"
        },
        legend: {
        display: false
        },
        tooltips: {
            callbacks: {
            label: function(tooltipItem) {
                    return tooltipItem.yLabel;
            }
            }
        },
        scales: {
        xAxes:[{
            ticks: {
                fontSize: 18
            }
        }],
        yAxes:[{
            ticks: {
                fontSize: 18,
                beginAtZero: true
            }
        }]
        }
    }
});



var yearly_income_expense_xValues = <?php echo json_encode($months); ?>;
var yearly_income_expense_yValues1 = <?php echo json_encode($yearly_incomes); ?>;
var yearly_income_expense_yValues2 = <?php echo json_encode($yearly_expenses); ?>;
var incomeColor = "blue";
var expenseColor = "red";

new Chart("yearly_income_expense", {
  type: "bar",
  data: {
    labels: yearly_income_expense_xValues,
    datasets: [{
      label: "Income",
      backgroundColor: incomeColor,
      data: yearly_income_expense_yValues1,
      barPercentage: 0.6,
    },{
      label: "Expense",
      backgroundColor: expenseColor,
      data: yearly_income_expense_yValues2,
      barPercentage: 0.6,
    }]
  },
  options: {
        maintainAspectRatio: false,
        title: {
        fontSize: 18,
        display: true,
        text: "Yearly income expense breakdown"
        },
        scales: {
            xAxes:[{
                ticks: {
                    fontSize: 18
                }
            }],
            yAxes:[{
                ticks: {
                    fontSize: 18,
                    beginAtZero: true
                }
            }]
        },
        legend: {
            labels: {
                fontSize: 14
            }
        }
    }
});

</script>