#!/bin/ksh
# 
echo running 'process_moh_proposed_prices.com'

awk -f $cmd/massage_moh_prices.awk < moh_proposed_prices.var  > moh_proposed_prices.ps
