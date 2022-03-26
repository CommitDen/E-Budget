<head>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.9.4/Chart.js"></script>
</head>
    <div class="row">
        <div class="col-sm-6">
            <canvas id="monthly_expense" style="width:100%;max-width:700px"></canvas>
        </div>
        <div class="col-sm-6">
            <canvas id="monthly_income_expense" style="width:100%;max-width:700px"></canvas>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-10 offset-sm-1">
            <canvas id="yearly_income_expense" style="width:100%;max-width:1400px;max-height:750px"></canvas>
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
var monthly_income_expense_yValues = <?php echo json_encode($income_amounts); ?>;
var barColors2 = ["blue", "red"];

new Chart("monthly_income_expense", {
  type: "bar",
  data: {
    labels: monthly_income_expense_xValues,
    datasets: [{
      backgroundColor: barColors2,
      data: monthly_income_expense_yValues
    }]
  },
  options: {
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
            barPercentage: 0.6,
            ticks: {
                fontSize: 18
            }
        }],
        yAxes:[{
            ticks: {
                fontSize: 18
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
      data: yearly_income_expense_yValues1
    },{
      label: "Expense",
      backgroundColor: expenseColor,
      data: yearly_income_expense_yValues2
    }]
  },
  options: {
        title: {
        fontSize: 18,
        display: true,
        text: "Yearly income expense breakdown"
        },
        scales: {
            xAxes:[{
                barPercentage: 0.6,
                ticks: {
                    fontSize: 18
                }
            }],
            yAxes:[{
                ticks: {
                    fontSize: 18
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