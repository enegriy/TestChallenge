using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp9
{
    public class Device
    {
        public Device(string version, List<Device> children)
        {
            Version = version;
            Children = children;
        }

        public string Version { get; }
        public List<Device> Children { get; }
    }

    public class Solver
    {
        public IEnumerable<T> FindDistinct<T>(Device rootDevice, Func<Device, T> getPropFunc)
        {
            var result = new HashSet<T>();
            var devices = new Stack<Device>();

            devices.Push(rootDevice);

            while (devices.Any())
            {
                var device = devices.Pop();
                if (device.Children.Any())
                {
                    foreach (var dev in device.Children)
                    {
                        devices.Push(dev);
                    }
                }

                result.Add(getPropFunc(device));
            }
            return result;
        }

        public IEnumerable<string> FindDistinctVersions(Device rootDevice)
        {
            return FindDistinct(rootDevice, x => x.Version);
        }
    }
}
