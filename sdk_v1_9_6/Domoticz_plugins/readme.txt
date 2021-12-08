firmware version <=2.16.x                   dingtian_v1_1
firmware version >=2.17.x                   dingtian_v1_2
firmware version <=2.16.x and >=2.17.x      dingtian_v1_3

1 stop Domoticz
creator directory:
Domoticz\plugins

2 copy Dingtian Relay plugins(dingtian_v1_1/dingtian_v1_2/dingtian_v1_3) to Domoticz plugins directory, 
and rename as dingtian, path like below:
Domoticz\plugins\dingtian

3 restart Domoticz

4 add new device
Setup -> Hardware
Name: dingtian-relay
Type: Dingtian Relay
IP Address: 192.168.1.100
Port: 60001
Channel: 2/4/8(select your relay board channel)
Password: 0
Parity Mutex:false
Debug: false

click "Add" button to add Dingtian Relay to Domoticz

5 switch to "Switches" page,your can control relay,good luck

addtion:
1 Domoticz add many relay board
config at relay board web page: 
dingtian binary port:60000/60002/60004/60006....
dingtian string port:60001/60003/60005/60007....

config at Domoticz: 
Port: 60001/60003/60005/60007....