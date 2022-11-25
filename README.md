## How to set the Expander/collpase behavior for GridHeaderIndentCell in WPF DataGrid (SfDataGrid)
## About the sample

This example illustrates how to set the expander/collpase behavior for GridHeaderIndentCell in [WPF DataGrid](https://www.syncfusion.com/wpf-ui-controls/datagrid) (SfDataGrid).

[WPF DataGrid](https://www.syncfusion.com/wpf-ui-controls/datagrid) (SfDataGrid) does not provide the support for setting expander in `GridHeaderIndentCell`. You can achieve this by overriding the `GridHeaderIndentCell` style and using the `GridHeaderIndentCell.MouseDown` event, you can change the expand or collapse state of all the DetailViewDataGrid rows.

```XAML
<Style TargetType="syncfusion:GridHeaderIndentCell">
    <Setter Property="BorderBrush" Value="Gray"/>
    <Setter Property="Template">
        <Setter.Value>
            <ControlTemplate TargetType="syncfusion:GridHeaderIndentCell">
                <Border Background="Transparent"
                    BorderBrush="{TemplateBinding BorderBrush}"
                    BorderThickness="{TemplateBinding BorderThickness}"
                    Padding="{TemplateBinding Padding}">
                    <VisualStateManager.VisualStateGroups>
                        <VisualStateGroup x:Name="ExpansionStates">
                            <VisualState x:Name="Expanded">
                                <Storyboard>
                                    <ObjectAnimationUsingKeyFrames Storyboard.TargetName="PART_CollapseCellPath" Storyboard.TargetProperty="(FrameworkElement.Visibility)">
                                        <DiscreteObjectKeyFrame Value="{x:Static Visibility.Collapsed}" KeyTime="0:0:0"/>

                                    </ObjectAnimationUsingKeyFrames>
                                    <ObjectAnimationUsingKeyFrames Storyboard.TargetName="PART_ExpanderCellPath" Storyboard.TargetProperty="(FrameworkElement.Visibility)">
                                        <DiscreteObjectKeyFrame Value="{x:Static Visibility.Visible}" KeyTime="0:0:0" />

                                    </ObjectAnimationUsingKeyFrames>
                                </Storyboard>
                            </VisualState>
                            <VisualState x:Name="Collapsed">
                                <Storyboard>
                                    <ObjectAnimationUsingKeyFrames Storyboard.TargetName="PART_CollapseCellPath" Storyboard.TargetProperty="(FrameworkElement.Visibility)">
                                        <DiscreteObjectKeyFrame Value="{x:Static Visibility.Visible}" KeyTime="0:0:0"/>

                                    </ObjectAnimationUsingKeyFrames>
                                    <ObjectAnimationUsingKeyFrames Storyboard.TargetName="PART_ExpanderCellPath" Storyboard.TargetProperty="(FrameworkElement.Visibility)">
                                        <DiscreteObjectKeyFrame Value="{x:Static Visibility.Collapsed}" KeyTime="0:0:0"/>
                                    </ObjectAnimationUsingKeyFrames>

                                </Storyboard>
                            </VisualState>
                        </VisualStateGroup>
                    </VisualStateManager.VisualStateGroups>
                    <Grid Background="{TemplateBinding Background}" Margin="{TemplateBinding Padding}">
                        <Path Margin="7" x:Name="PART_CollapseCellPath"
                      Width="{TemplateBinding Width}"
                      Height="{TemplateBinding Height}"
                      HorizontalAlignment="Center"
                      VerticalAlignment="Center"
                      Data="F1M1464.78,374.21C1466.31,374.21,1466.94,375.538,1466.17,376.861L1435.89,429.439C1435.12,430.759,1433.87,430.823,1433.11,429.5L1402.82,376.827C1402.06,375.507,1402.69,374.21,1404.21,374.21L1464.78,374.21"
                      Fill="{TemplateBinding Foreground}"
                      SnapsToDevicePixels="True"
                      Stretch="Fill"
                      Stroke="{TemplateBinding Foreground}"
                      UseLayoutRounding="False">
                            <Path.RenderTransform>
                                <TransformGroup>
                                    <TransformGroup.Children>
                                        <RotateTransform Angle="270" CenterX="4" CenterY="4" />
                                    </TransformGroup.Children>
                                </TransformGroup>
                            </Path.RenderTransform>
                        </Path>
                        <Path x:Name="PART_ExpanderCellPath" Margin="7"
                      Width="{TemplateBinding Width}"
                      Height="{TemplateBinding Height}"
                      HorizontalAlignment="Center"
                      VerticalAlignment="Center"
                      Data="F1M1464.78,374.21C1466.31,374.21,1466.94,375.538,1466.17,376.861L1435.89,429.439C1435.12,430.759,1433.87,430.823,1433.11,429.5L1402.82,376.827C1402.06,375.507,1402.69,374.21,1404.21,374.21L1464.78,374.21"
                      Fill="{TemplateBinding Foreground}"
                      SnapsToDevicePixels="True"
                      Stretch="Fill"
                      Visibility="Collapsed"        
                      Stroke="{TemplateBinding Foreground}"
                      UseLayoutRounding="False">
                            <Path.RenderTransform>
                                <TransformGroup>
                                    <TransformGroup.Children>
                                        <RotateTransform Angle="0" CenterX="4" CenterY="4" />
                                    </TransformGroup.Children>
                                </TransformGroup>
                            </Path.RenderTransform>
                        </Path>
                    </Grid>
                </Border>
            </ControlTemplate>
        </Setter.Value>
    </Setter>
    <EventSetter Event="MouseDown" Handler="GridHeaderIndentCell_MouseDown" />
</Style>
```

```c#
 private void GridHeaderIndentCell_MouseDown(object sender, MouseButtonEventArgs e)
{
    var gridHeaderIndentCell = sender as GridHeaderIndentCell;
    IsExpanded = !IsExpanded;
    usetransition = true;
    VisualStateManager.GoToState(gridHeaderIndentCell, IsExpanded ? "Expanded" : "Collapsed", usetransition);
    usetransition = false;
    if (IsExpanded)
        this.dataGrid.ExpandAllDetailsView();
    else
        this.dataGrid.CollapseAllDetailsView();
}
```

KB article - [How to set the expander/collpase behavior for GridHeaderIndentCell in WPF SfDataGrid](https://www.syncfusion.com/kb/11518/how-to-set-the-expander-collpase-behavior-for-gridheaderindentcell-in-wpf-datagrid)

## Requirements to run the demo
Visual Studio 2015 and above versions

