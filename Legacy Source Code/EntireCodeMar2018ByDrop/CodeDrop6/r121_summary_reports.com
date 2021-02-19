#!/bin/ksh
# 2015/Jan/19   MC   $cmd/r121_summary_reports.com

cd $application_root/production;pwd

echo "r121_summary_reports.com  -  STARTING - `date`" > r121_summary_reports.log

# you must define the calendar year below as the parameter
$cmd/r121_summary_reports 2014  		     >> r121_summary_reports.log

echo "r121_summary_reports.com - ENDING - `date`"    >> r121_summary_reports.log

