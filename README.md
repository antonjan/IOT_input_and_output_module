# IOT_input_and_output_module
This project will have all the code of the Giga Technology IOT Input and output units<br>
## Operating Manual
<a href="https://github.com/antonjan/IOT_input_and_output_module/blob/main/doc/user_manual_en.pdf"> Operating manual</a><br>
## Modules
1) 2 input and 2 output Module<br>
2) 4 input and 4 output Module<b> 
    The configeration below is similar for both modules<br>
![Alt text](images/mqtt_2in_2out_Cont_12.png?raw=true "2in 2 out Module")<br>
![Alt text](images/mqtt_2in_2out_Cont_11.png?raw=true "2in 2 out Module")<br>
![Alt text](images/mqtt_2in_2out_Cont_10.png?raw=true "2in 2 out Module")<br>
![Alt text](images/mqtt_2in_2out_Cont_8.png?raw=true "2in 2 out Module")<br>    
Product Overview

    Support multiple channel relay, On/OFF/Jogging/Delay.
    Support multiple interface RJ45/RS485/CAN/WIFI
    Support HTTP GET CGI/UDP/TCP Server/TCP Client
    10/100Mbps ethernet, Auto-MDIX,DHCP ip,Static IP
    Local Button control(SelfLock/Jogging/Delay)
    WEB config and control
    Support password.
    Support Modbus-RTU/ASCII/TCP/UDP/WIFI
    Support Modbus-RTU Over TCP/UDP/WIFI
    Support Modbus-ASCII Over TCP/UDP/WIFI
    Support MQTT(Ethernet and WIFI)
    Support CoAP
    Support Domoticz
    Support Home Assistant
    Support Node-RED
# Operating

Connect 12V to power supply

## Connect to device wifi AP directely pw dtpassword
![Alt text](images/mqtt_2in_2out_Cont_15.png?raw=true "2in 2 out Module")<br>

## Configer wifi and MQTT details
got url in browser http://192.168.7.1 Login with admin admin
![Alt text](images/mqtt_2in_2out_Cont_2.png?raw=true "2in 2 out Module")<br>
Now select settings and configure your wifi setting as shown in RED<br>
![Alt text](images/mqtt_2in_2out_Cont_16.png?raw=true "2in 2 out Module")<br>

## Configure you MQTT
Select Relay Conect<br>
Then enter your MQTT details as shown in the RED sections<br>
![Alt text](images/mqtt_2in_2out_Cont_17.png?raw=true "2in 2 out Module")<br>

    

# Node-RED<br>
Now lets controle the GT Relay and input module by connecting you Node-RED to your mqtt<br>
Below is a working exsample to read the inputs and control the rlay outputs for the unit<br>
Node red flow code can be downloaded here <a href="https://github.com/antonjan/IOT_input_and_output_module/blob/main/node-red/flows_gt_mqtt_relay.json">Node red exsample flow code </a> <br>
![Alt text](images/mqtt_2in_2out_Cont_13.png?raw=true "2in 2 out Module")<br>
<a href="https://github.com/antonjan/IOT_input_and_output_module/blob/main/node-red/flows_gt_mqtt_relay.json">Node red exsample flow code </a> <br>
![Alt text](images/mqtt_2in_2out_Cont_18.png?raw=true "2in 2 out Module")<br>
