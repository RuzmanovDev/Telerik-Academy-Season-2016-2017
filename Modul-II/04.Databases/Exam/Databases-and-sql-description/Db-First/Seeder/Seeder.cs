using Seeder.Data;
using System.Collections.Generic;
using System.Linq;

namespace Seeder
{
    public class Seeder
    {
        private const int NumberOfGpus = 15;
        private const int NumberOfCpus = 10;
        private const int NumberOfStorageDevices = 30;
        private const int NumberOfComputers = 50;

        private readonly IRandomProvider randomProvider;
        private ComputersEntities context;

        public Seeder(IRandomProvider randomProvider, ComputersEntities context)
        {
            this.randomProvider = randomProvider;
            this.context = context;
        }

        public void SeedComputerTypes()
        {
            string[] types = { "Notebook", "Desktop", "Ultrabook" };

            foreach (var type in types)
            {
                this.context.ComputerTypes.Add(new ComputerType()
                {
                    TypeName = type
                });
            }

            this.context.SaveChanges();
        }

        public void SeedGPUTypes()
        {
            string[] types = { "internal", "external" };

            foreach (var type in types)
            {
                this.context.GPUTypes.Add(new GPUType()
                {
                    TypeName = type
                });
            }

            this.context.SaveChanges();
        }

        public void SeedStorageDevisesTypes()
        {
            string[] types = { "SSD", "HDD" };

            foreach (var type in types)
            {
                this.context.StorageDevicesTypes.Add(new StorageDevicesType()
                {
                    TypeName = type
                });
            }

            this.context.SaveChanges();
        }

        public void SeedGpus()
        {
            var typeIdForInternal = this.context.GPUTypes.FirstOrDefault(t => t.TypeName == "internal").Id;
            var typeIdForExternal = this.context.GPUTypes.FirstOrDefault(t => t.TypeName == "external").Id;

            for (int i = 0; i < NumberOfGpus; i++)
            {
                if (i < 5)
                {
                    var gpu = new GPU()
                    {
                        TypeId = typeIdForInternal,
                        Vendor = this.randomProvider.RandomString(3, 10),
                        Model = this.randomProvider.RandomString(4, 10),
                        Memory = this.randomProvider.RandomNumber(2, 64)
                    };
                    this.context.GPUs.Add(gpu);
                    this.context.SaveChanges();
                }
                else
                {
                    var gpu = new GPU()
                    {
                        TypeId = typeIdForExternal,
                        Vendor = this.randomProvider.RandomString(3, 10),
                        Model = this.randomProvider.RandomString(4, 10),
                        Memory = this.randomProvider.RandomNumber(2, 64)
                    };
                    this.context.GPUs.Add(gpu);
                    this.context.SaveChanges();
                }
            }
            this.context.SaveChanges();

        }

        public void SeedCpus()
        {
            for (int i = 0; i < NumberOfCpus; i++)
            {
                var cpu = new CPU()
                {
                    Vendor = this.randomProvider.RandomString(3, 10),
                    Model = this.randomProvider.RandomString(3, 10),
                    NumberOfCores = this.randomProvider.RandomNumber(1, 64),
                    ClockCycles = this.randomProvider.RandomNumber(2, 5) + ".5 GHz"
                };
                this.context.CPUs.Add(cpu);
            }

            this.context.SaveChanges();
        }

        public void SeedSorageDevices()
        {
            var hddId = this.context.StorageDevicesTypes.FirstOrDefault(t => t.TypeName == "HDD").Id;
            var ssdId = this.context.StorageDevicesTypes.FirstOrDefault(t => t.TypeName == "SSD").Id;

            for (int i = 0; i < NumberOfStorageDevices; i++)
            {
                StorageDevice storageDevice;
                if (i < 8)
                {
                    storageDevice = this.GenerateStoraDevice(ssdId);
                }
                else
                {
                    storageDevice = this.GenerateStoraDevice(hddId);
                }

                this.context.StorageDevices.Add(storageDevice);
            }
            this.context.SaveChanges();
        }

        public void SeedComputers()
        {
            var notebooksId = this.context.ComputerTypes.FirstOrDefault(t => t.TypeName == "Notebook").Id;
            var desktopId = this.context.ComputerTypes.FirstOrDefault(t => t.TypeName == "Desktop").Id;
            var ultrabookId = this.context.ComputerTypes.FirstOrDefault(t => t.TypeName == "Ultrabook").Id;
            for (int i = 0; i < NumberOfComputers; i++)
            {
                Computer computer;
                if (i < 16)
                {
                    computer = GenerateComputer(notebooksId);
                }
                else if (i > 16 && i < 32)
                {
                    computer = GenerateComputer(desktopId);
                }
                else
                {
                    computer = GenerateComputer(ultrabookId);
                }

                this.context.Computers.Add(computer);
            }

            this.context.SaveChanges();
        }
        private StorageDevice GenerateStoraDevice(int typeId)
        {
            var device = new StorageDevice()
            {
                TypeId = typeId,
                Vendor = this.randomProvider.RandomString(3, 10),
                Model = this.randomProvider.RandomString(3, 10),
                Size = this.randomProvider.RandomNumber(1, 2000)
            };

            return device;
        }

        private Computer GenerateComputer(int typeOfPc)
        {
            var gpus = this.context.GPUs.ToList();
            var cpus = this.context.CPUs.Select(g => g.Id).ToList();
            var hdd = this.context.StorageDevices.ToList();

            return new Computer()
            {
                TypeId = typeOfPc,
                CPUId = cpus[this.randomProvider.RandomNumber(0, cpus.Count - 1)],
                Model = this.randomProvider.RandomString(3, 10),
                Vendor = this.randomProvider.RandomString(3, 10),
                GPUs = new List<GPU>() { gpus[0], gpus[1] },
                StorageDevices = new List<StorageDevice>() { hdd[0], hdd[1] },
                RAM = this.randomProvider.RandomNumber(1,64)
            };
        }
    }
}
