﻿using System;
using System.Linq;
using FirstFloor.ModernUI.Helpers;
using FirstFloor.ModernUI.Presentation;

namespace AcManager.Tools.Helpers {
    public static partial class SettingsHolder {
        public class IntegratedSettings : NotifyPropertyChanged {
            internal IntegratedSettings() { }

            private DelayEntry[] _periodEntries;

            public DelayEntry[] Periods => _periodEntries ?? (_periodEntries = new[] {
                new DelayEntry(TimeSpan.FromHours(1)),
                new DelayEntry(TimeSpan.FromHours(3)),
                new DelayEntry(TimeSpan.FromHours(6)),
                new DelayEntry(TimeSpan.FromHours(12)),
                new DelayEntry(TimeSpan.FromDays(1))
            });

            private bool? _discordIntegration;

            public bool DiscordIntegration {
                get => _discordIntegration ?? (_discordIntegration = ValuesStorage.Get("Settings.IntegratedSettings.DiscordIntegration", true)).Value;
                set {
                    if (Equals(value, _discordIntegration)) return;
                    _discordIntegration = value;
                    ValuesStorage.Set("Settings.IntegratedSettings.DiscordIntegration", value);
                    OnPropertyChanged();
                }
            }

            private DelayEntry _theSetupMarketCacheListPeriod;

            public DelayEntry TheSetupMarketCacheListPeriod {
                get {
                    var saved = ValuesStorage.Get<TimeSpan?>("Settings.IntegratedSettings.TheSetupMarketCacheListPeriod");
                    return _theSetupMarketCacheListPeriod ?? (_theSetupMarketCacheListPeriod = Periods.FirstOrDefault(x => x.TimeSpan == saved) ??
                            Periods.ElementAt(3));
                }
                set {
                    if (Equals(value, _theSetupMarketCacheListPeriod)) return;
                    _theSetupMarketCacheListPeriod = value;
                    ValuesStorage.Set("Settings.IntegratedSettings.TheSetupMarketCacheListPeriod", value.TimeSpan);
                    OnPropertyChanged();
                }
            }

            private DelayEntry _theSetupMarketCacheDataPeriod;

            public DelayEntry TheSetupMarketCacheDataPeriod {
                get {
                    var saved = ValuesStorage.Get<TimeSpan?>("Settings.IntegratedSettings.TheSetupMarketCacheDataPeriod");
                    return _theSetupMarketCacheDataPeriod ?? (_theSetupMarketCacheDataPeriod = Periods.FirstOrDefault(x => x.TimeSpan == saved) ??
                            Periods.ElementAt(2));
                }
                set {
                    if (Equals(value, _theSetupMarketCacheDataPeriod)) return;
                    _theSetupMarketCacheDataPeriod = value;
                    ValuesStorage.Set("Settings.IntegratedSettings.TheSetupMarketCacheDataPeriod", value.TimeSpan);
                    OnPropertyChanged();
                }
            }

            private bool? _theSetupMarketCacheServer;

            public bool TheSetupMarketCacheServer {
                get => _theSetupMarketCacheServer ?? (_theSetupMarketCacheServer =
                        ValuesStorage.Get("Settings.IntegratedSettings.TheSetupMarketCacheServer2", true)).Value;
                set {
                    if (Equals(value, _theSetupMarketCacheServer)) return;
                    _theSetupMarketCacheServer = value;
                    ValuesStorage.Set("Settings.IntegratedSettings.TheSetupMarketCacheServer2", value);
                    OnPropertyChanged();
                }
            }

            private bool? _theSetupMarketTab;

            public bool TheSetupMarketTab {
                get => _theSetupMarketTab ?? (_theSetupMarketTab = ValuesStorage.Get("Settings.IntegratedSettings.TheSetupMarketTab", false)).Value;
                set {
                    if (Equals(value, _theSetupMarketTab)) return;
                    _theSetupMarketTab = value;
                    ValuesStorage.Set("Settings.IntegratedSettings.TheSetupMarketTab", value);
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(TheSetupMarketCounter));
                }
            }

            private bool? _theSetupMarketCounter;

            public bool TheSetupMarketCounter {
                get => TheSetupMarketTab && (_theSetupMarketCounter ??
                        (_theSetupMarketCounter = ValuesStorage.Get("Settings.IntegratedSettings.TheSetupMarketCounter", false)).Value);
                set {
                    if (Equals(value, _theSetupMarketCounter)) return;
                    _theSetupMarketCounter = value;
                    ValuesStorage.Set("Settings.IntegratedSettings.TheSetupMarketCounter", value);
                    OnPropertyChanged();
                }
            }

            private bool? _rsrLimitTemperature;

            public bool RsrLimitTemperature {
                get => _rsrLimitTemperature ?? (_rsrLimitTemperature = ValuesStorage.Get("Settings.IntegratedSettings.RsrLimitTemperature", true)).Value;
                set {
                    if (Equals(value, _rsrLimitTemperature)) return;
                    _rsrLimitTemperature = value;
                    ValuesStorage.Set("Settings.IntegratedSettings.RsrLimitTemperature", value);
                    OnPropertyChanged();
                }
            }

            /*private bool? _dBoxIntegration;

            public bool DBoxIntegration {
                get => _dBoxIntegration ?? (_dBoxIntegration = ValuesStorage.Get("Settings.IntegratedSettings.DBoxIntegration", false)).Value;
                set {
                    if (Equals(value, _dBoxIntegration)) return;
                    _dBoxIntegration = value;
                    ValuesStorage.Set("Settings.IntegratedSettings.DBoxIntegration", value);
                    OnPropertyChanged();
                }
            }

            private string _dBoxLocation;

            public string DBoxLocation {
                get => _dBoxLocation ?? (_dBoxLocation = ValuesStorage.Get("Settings.IntegratedSettings.DBoxLocation", ""));
                set {
                    value = value.Trim();
                    if (Equals(value, _dBoxLocation)) return;
                    _dBoxLocation = value;
                    ValuesStorage.Set("Settings.IntegratedSettings.DBoxLocation", value);
                    OnPropertyChanged();
                }
            }

            private DelegateCommand _selectDBoxLocationCommand;

            public DelegateCommand SelectDBoxLocationCommand => _selectDBoxLocationCommand ?? (_selectDBoxLocationCommand = new DelegateCommand(() => {
                DBoxLocation = FileRelatedDialogs.Open(new OpenDialogParams {
                    DirectorySaveKey = "dbox",
                    Filters = {
                        new DialogFilterPiece("D-Box Helper", "ACWithLiveMotion.exe"),
                        DialogFilterPiece.Applications,
                        DialogFilterPiece.AllFiles,
                    },
                    Title = "Select D-Box application",
                    DefaultFileName = Path.GetFileName(DBoxLocation),
                }) ?? DBoxLocation;
            }));*/
        }

        private static IntegratedSettings _integrated;
        public static IntegratedSettings Integrated => _integrated ?? (_integrated = new IntegratedSettings());
    }
}