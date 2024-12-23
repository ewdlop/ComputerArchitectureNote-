Certainly! In addition to Zeek's scripting language, there are several other scripting languages commonly used for network analysis, security, and automation. Here are a few notable ones:

### Python
Python is widely used for network automation, data analysis, and security scripting due to its readability and extensive libraries.

#### Example: Simple Network Scanner

```python
import socket

def scan_port(ip, port):
    sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    sock.settimeout(1)
    try:
        sock.connect((ip, port))
    except:
        return False
    return True

def scan_ports(ip):
    open_ports = []
    for port in range(1, 1025):
        if scan_port(ip, port):
            open_ports.append(port)
    return open_ports

ip = "192.168.1.1"
open_ports = scan_ports(ip)
print(f"Open ports on {ip}: {open_ports}")
```

### Bash
Bash scripting is often used for automating tasks on Unix-based systems, including network monitoring and log analysis.

#### Example: Simple Ping Sweep

```bash
#!/bin/bash

network="192.168.1"

for ip in $(seq 1 254); do
    ping -c 1 -W 1 $network.$ip &> /dev/null && echo "Host $network.$ip is up"
done
```

### PowerShell
PowerShell is a task automation and configuration management framework from Microsoft, consisting of a command-line shell and associated scripting language.

#### Example: Simple Network Scanner

```powershell
$ip = "192.168.1.1"
1..1024 | ForEach-Object {
    $port = $_
    $tcp = New-Object Net.Sockets.TcpClient
    try {
        $tcp.Connect($ip, $port)
        $tcp.Close()
        Write-Host "Port $port is open"
    } catch {
        # Port is closed
    }
}
```

### Perl
Perl is known for its text processing capabilities and is used in network administration and security tasks.

#### Example: Simple Port Scanner

```perl
use IO::Socket;

my $ip = "192.168.1.1";
my @ports = (1..1024);

foreach my $port (@ports) {
    my $socket = IO::Socket::INET->new(
        PeerAddr => $ip,
        PeerPort => $port,
        Proto    => 'tcp',
        Timeout  => 1
    );
    if ($socket) {
        print "Port $port is open\n";
        close($socket);
    }
}
```

### Lua
Lua is a lightweight scripting language often embedded in applications for configuration and scripting purposes.

#### Example: Simple HTTP Request

```lua
local http = require("socket.http")

local response = {}
local res, code, headers = http.request{
    url = "http://example.com",
    sink = ltn12.sink.table(response)
}

if code == 200 then
    print(table.concat(response))
else
    print("Request failed with code: " .. code)
end
```

Each of these scripting languages has its own strengths and use cases, making them valuable tools for network administrators, security professionals, and developers.
