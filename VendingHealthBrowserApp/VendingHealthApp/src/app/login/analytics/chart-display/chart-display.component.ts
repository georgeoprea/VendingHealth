import {Component, ElementRef, Input, OnInit, ViewChild} from '@angular/core';
import {ChartService} from "../chart.service";
import {UserCard} from "../user-card.model";
import {PlotData} from "./plot-data.model";

@Component({
  selector: 'app-chart-display',
  templateUrl: './chart-display.component.html',
  styleUrls: ['./chart-display.component.css']
})
export class ChartDisplayComponent implements OnInit {

  @Input()
  usernameAndCard : UserCard;

  @ViewChild('chart')
  private chartEl : ElementRef;

  private date: string;

  constructor(private chartService: ChartService,) { }

  ngOnInit() {
    this.chartService
      .getHourlyTransactionNumber(this.usernameAndCard)
      .subscribe(
        (data) => {
          console.log(data);
          this.createCharts(data);
        }
      );

  }

  createCharts(chartData: PlotData[]) {
    const element = this.chartEl.nativeElement;

    const layout = {
      margin:{t:0},
      xaxis: {
        title: 'Hour',
        titlefont: {
          size: 18,
          color: '#7f7f7f'
        },
        autotick: false,
        ticks: 'outside',
        tick0: 0,
        dtick: 1,
      },
      yaxis: {
        title: 'Products Consumed',
        titlefont: {
          size: 18,
          color: '#7f7f7f'
        },
        autotick: false,
        ticks: 'outside',
        tick0: 0,
        dtick: 1,
      }
    };

    let hourNow = new Date().getHours();
    let hours = new Array(24);
    let plotX: number[] = [];

    for(let hour = 0; hour < hours.length; hour++)
      plotX.push(hour);

    let plotY: number[] = new Array(24);
    plotY.fill(0);

    for(let plotPoint of chartData)
      if(plotPoint.hour != 'day')
        plotY.splice(parseInt(plotPoint.hour), 0, parseInt(plotPoint.vendedItems));
      else
        this.date = plotPoint.vendedItems;

    const data = [{
      x: plotX,
      y: plotY
    }];

    Plotly.plot(element, data, layout);
  }

}
