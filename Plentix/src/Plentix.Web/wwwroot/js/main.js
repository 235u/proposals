'use strict';

/*
  eslint-disable prefer-arrow-callback, func-names, vars-on-top, prefer-destructuring,
  prefer-template, consistent-return
*/

(function($) {
  var Highcharts = window.Highcharts;
  var isMobile = $(window).width() < 992;
  var navbar = $('.navbar');

  if (
    navigator.appName == 'Microsoft Internet Explorer' ||
    !!(
      navigator.userAgent.match(/Trident/) || navigator.userAgent.match(/rv:11/)
    ) ||
    (typeof $.browser !== 'undefined' && $.browser.msie == 1)
  ) {
    $('body').addClass('is-ie');
  }

  function stickNavbar() {
    if (window.scrollY < 100 && $(window).width() > 1087) {
      navbar.removeClass('is-stick');
    } else {
      navbar.addClass('is-stick');
    }
  }

  $(window)
    .on('scroll', stickNavbar)
    .trigger('scroll');
  $(window)
    .on('resize', stickNavbar)
    .trigger('resize');

  $('.navbar-burger').on('click', function(e) {
    e.preventDefault();
    $(this).toggleClass('is-active');
    $('.navbar-menu').toggleClass('is-active');
  });

  $('a[href*="#"]')
    .not('[href="#"]')
    .not('[href="#0"]')
    .on('click', function(e) {
      if (
        window.location.pathname.replace(/^\//, '') ===
          this.pathname.replace(/^\//, '') &&
        window.location.hostname === this.hostname
      ) {
        var target = $(this.hash);
        target = target.length
          ? target
          : $('[name=' + this.hash.slice(1) + ']');
        if (target.length) {
          e.preventDefault();
          $('html, body').animate(
            {
              scrollTop: target.offset().top - 80
            },
            1000
          );
        }
      }
    });

  $('.press__logos').slick({
    slidesToShow: 6,
    autoplay: true,
    autoplaySpeed: 2000,
    arrows: false,
    dots: false,
    responsive: [
      {
        breakpoint: 1023,
        settings: {
          slidesToShow: 4
        }
      },
      {
        breakpoint: 767,
        settings: {
          slidesToShow: 1
        }
      }
    ]
  });

  $('.roadmap-content__carousel').slick({
    slidesToShow: 1,
    dots: false,
    asNavFor: '.roadmap',
    fade: true,
    initialSlide: 1,
    draggable: false,
    appendArrows: $('.roadmap-content__arrows'),
    prevArrow:
      '<button><svg><use xlink:href="#angle-left"></use></svg></button>',
    nextArrow:
      '<button><svg><use xlink:href="#angle-right"></use></svg></button>'
  });

  $('.roadmap').slick({
    slidesToShow: 5,
    slidesToScroll: 1,
    dots: false,
    asNavFor: '.roadmap-content__carousel',
    centerMode: true,
    focusOnSelect: true,
    arrows: false,
    initialSlide: 1,
    responsive: [
      {
        breakpoint: 1023,
        settings: {
          slidesToShow: 4
        }
      },
      {
        breakpoint: 767,
        settings: {
          slidesToShow: 1
        }
      }
    ]
  });

  $('[data-modal="true"]').on('click', function(e) {
    e.preventDefault();
    var modal = $('#video-modal');
    var iframe = modal.find('iframe');
    var videoSrc =
      $(this).attr('href') +
      '?modestbranding=1&rel=0&controls=0&showinfo=0&html5=1&autoplay=1';
    iframe.attr('src', videoSrc);
    modal.addClass('is-active');
  });

  $('.modal-close, .modal-background').on('click', function(e) {
    e.preventDefault();
    var modal = $('#video-modal');
    var iframe = modal.find('iframe');
    iframe.attr('src', '');
    modal.removeClass('is-active');
  });

  var defaultChartOptions = {
    chart: {
      plotBackgroundColor: null,
      plotBorderWidth: null,
      plotShadow: false,
      backgroundColor: null,
      type: 'pie',
      marginRight: isMobile ? 0 : 0
    },
    title: {
      text: false
    },
    tooltip: {
      pointFormat: '<b>{point.percentage:.1f}%</b>'
    },
    plotOptions: {
      pie: {
        size: isMobile ? 230 : 300,
        allowPointSelect: true,
        cursor: 'pointer',
        dataLabels: {
          enabled: false
        },
        borderWidth: 0,
        showInLegend: true,
        point: {
          events: {
            legendItemClick: function legendItemClick(e) {
              e.preventDefault();
            }
          }
        }
      }
    },
    credits: {
      enabled: false
    },
    legend: {
      align: isMobile ? 'center' : 'right',
      verticalAlign: isMobile ? 'bottom' : 'top',
      layout: 'vertical',
      x: isMobile ? 0 : -100,
      y: isMobile ? 0 : 100,
      itemStyle: {
        color: '#fff',
        fontSize: '14px',
        fontFamily: 'Lato, sans-serif',
        fontWeight: 500,
        margin: 20
      },
      labelFormatter: function labelFormatter() {
        return '<b>' + this.y + '%</b> ' + this.name;
      }
    }
  };

  var tokenChartOptions = $.extend({}, defaultChartOptions, {
    colors: ['#6689FF', '#7DACFF', '#8BB5FF', '#9FC2FF', '#B3CEFF', '#d7e5ff'],
    series: [
      {
        name: null,
        colorByPoint: true,
        data: [
          {
            name: 'Token Sale',
            y: 70,
            sliced: true,
            selected: true
          },
          {
            name: 'Founders & Team Members',
            y: 15
          },
          {
            name: 'Advisors, Referral & Bounty',
            y: 5
          },
          {
            name: 'Strategic Partners',
            y: 5
          },
          {
            name: 'Community & Referral',
            y: 3
          },
          {
            name: 'Liquidity Reserve',
            y: 2
          }
        ]
      }
    ]
  });

  var budgetChartOptions = $.extend({}, defaultChartOptions, {
    colors: ['#F78469', '#FF9279', '#FB9D86', '#FDAA96', '#FFBDAD', '#FFCCBF'],
    series: [
      {
        name: null,
        colorByPoint: true,
        data: [
          {
            name: 'Product Dev & Maintenance',
            y: 30,
            sliced: true,
            selected: true
          },
          {
            name: 'Business Growth & Dev',
            y: 25
          },
          {
            name: 'Marketing & Customer Dev',
            y: 15
          },
          {
            name: 'Reserve',
            y: 10
          },
          {
            name: 'Operations',
            y: 15
          },
          {
            name: 'Legal',
            y: 5
          }
        ]
      }
    ]
  });

  Highcharts.chart('token-chart', tokenChartOptions);
  // Highcharts.chart('budget-chart', budgetChartOptions);
})(jQuery);
