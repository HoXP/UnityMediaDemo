using UnityEngine;
using UnityEngine.Video;

public class VideoAPITest : MonoBehaviour
{
    private VideoPlayer vp = null;
    private MeshRenderer mr = null;

    private void Awake()
    {
        vp = GetComponent<VideoPlayer>();
        mr = GetComponent<MeshRenderer>();

        Init();
    }

    void Start()
    {
        mr.material.mainTexture = vp.texture;
        //vp.Play();
    }

    private void Init()
    {
        /*
         * Maximum number of audio tracks that can be controlled.
         * 只读
         */
        ushort controlledAudioTrackMaxCount = VideoPlayer.controlledAudioTrackMaxCount;
        print(string.Format("可控制的最大音轨数：{0}", controlledAudioTrackMaxCount));

        /*
         * Defines how the video content will be stretched to fill the target area.定义视频内容如何拉伸以填充目标区域。
         * 对应Aspect Ratio属性
         */
        vp.aspectRatio = VideoAspectRatio.FitHorizontally;
        /*
         * VideoAspectRatio枚举   Methods used to fit a video in the target area.用于在目标区域中适应视频的方法。
         *  NoScaling             Preserve the pixel size without adjusting for target area.保持像素大小而不调整目标区域。
         *  FitVertically         Resize proportionally so that height fits the target area, cropping or adding black bars on each side if needed.
         *                        按比例调整大小以使高度适合目标区域，如果需要，在每侧裁剪或添加黑条。
         *  FitHorizontally       Resize proportionally so that width fits the target area, cropping or adding black bars above and below if needed.
         *                        按比例调整大小以使宽度适合目标区域，如果需要，裁剪或在上方和下方添加黑条。
         *  FitInside             Resize proportionally so that content fits the target area, adding black bars if needed.按比例调整大小以使内容适合目标区域，如果需要，添加黑条。
         *  FitOutside            Resize proportionally so that content fits the target area, cropping if needed.按比例调整大小以使内容适合目标区域，并在需要时进行裁剪。
         *  Stretch               Resize non-proportionally to fit the target area.不按比例调整大小以适合目标区域。
         */

        /*
         * Destination for the audio embedded in the video.视频中嵌入的音频的目的地。
         * 对应Audio Output Mode属性
         */
        vp.audioOutputMode = VideoAudioOutputMode.AudioSource;
        /*
         * VideoAudioOutputMode枚举     Places where the audio embedded in a video can be sent.嵌入视频中的音频可发送的位置。
         *  None                        Disable the embedded audio.禁用嵌入音频。
         *  AudioSource                 Send the embedded audio into a specified AudioSource.将嵌入音频发送到指定的AudioSource。
         *  Direct                      Send the embedded audio direct to the platform's audio hardware.将嵌入音频直接发送到平台的音频硬件。
         */

        /*
         * Whether direct-output volume controls are supported for the current platform and video format. (Read Only)
         * 只读
         */
        bool canSetDirectAudioVolume = vp.canSetDirectAudioVolume;
        print(string.Format("当前平台和视频格式是否支持直接输出音量控制：{0}", canSetDirectAudioVolume));

        /*
         * Determines whether the VideoPlayer skips frames to catch up with current time. (Read Only)
         * 只读
         * true     如果当前由于某种原因VideoPlayer落后，则使VideoPlayer能够跳过帧以赶上当前播放时间。
         * false    确保播放所有帧而不跳过。
         */
        bool canSetSkipOnDrop = vp.canSetSkipOnDrop;
        print(string.Format("决定VideoPlayer是否跳过帧以赶上当前时间：{0}", canSetSkipOnDrop));

        /*
         * Whether current time can be changed using the time or timeFrames property. (Read Only)
         * 只读
         * 不是所有的场景下都支持seeking。如，在HTTP直播流中seeking可能没有意义。
         */
        bool canSetTime = vp.canSetTime;
        print(string.Format("是否可以使用time或timeFrames属性更改当前时间：{0}", canSetTime));

        /*
         * Whether the time source followed by the VideoPlayer can be changed. (Read Only)
         * 只读
         * 某些播放引擎只能跟随自己的内部时钟。
         */
        bool canSetTimeSource = vp.canSetTimeSource;
        print(string.Format("是否可以更改VideoPlayer后面的时间源：{0}", canSetTimeSource));

        /*
         * Returns true if the VideoPlayer can step forward through the video content. (Read Only)
         * 只读
         */
        bool canStep = vp.canStep;
        print(string.Format("VideoPlayer是否可以在视频内容中步进：{0}", canStep));

        /*
         * Number of audio tracks found in the data source currently configured.
         * 只读
         * 对于URL数据源，只有在数据源准备完成后才有效。
         */
        ushort audioTrackCount = vp.audioTrackCount;
        print(string.Format("在当前配置的数据源中找到的音轨数：{0}", audioTrackCount));

        /*
         * Number of audio tracks that this VideoPlayer will take control of.
         * 对应Controlled Tracks属性
         */
        ushort controlledAudioTrackCount = vp.controlledAudioTrackCount;
        print(string.Format("VideoPlayer将控制的音轨数量：{0}", controlledAudioTrackCount));

        /*
         * Reference time of the external clock the VideoPlayer uses to correct its drift.
         * 仅在VideoPlayer.timeReference设置为VideoTimeReference.ExternalTime时才相关。
         */
        double externalReferenceTime = 0;
        vp.externalReferenceTime = externalReferenceTime;
        print(string.Format("VideoPlayer用于校正其偏移的外部时钟的参考时间：{0}", vp.externalReferenceTime));
        
        /*
         * The clip being played by the VideoPlayer.
         * 对应Video Clip属性
         */
        print(string.Format("VideoPlayer播放的视频片段：{0}", vp.clip.name));

        #region Frame 帧
        /*
         * The frame index currently being displayed by the VideoPlayer.
         * 0基
         */
        print(string.Format("VideoPlayer当前显示的帧索引：{0}", vp.frame));

        /*
         * Number of frames in the current video content.
         * 可以在播放期间frameCount更改时调整此值。
         */
        print(string.Format("当前视频帧数：{0}", vp.frameCount));

        /*
         * The frame rate of the clip or URL in frames/second. (Read Only).
         * 单位：帧/秒；（只读）
         */
        print(string.Format("剪辑或URL的帧率：{0}", vp.frameRate));
        #endregion

        /*
         * Determines whether the VideoPlayer restarts from the beginning when it reaches the end of the clip.
         * 对应Loop属性
         */
        print(string.Format("是否循环播放：{0}", vp.isLooping));

        /*
         * Whether content is being played. (Read Only)
         * 调用VideoPlayer.Play不一定会导致isPlaying变为true。
         * VideoPlayer必须先成功准备内容才能开始播放。
         */
        print(string.Format("是否正在播放：{0}", vp.isPlaying));

        #region Prepare 准备
        /*
         * Whether the VideoPlayer has successfully prepared the content to be played. (Read Only)
         * 只读
         * 执行VideoPlayer.Prepare()，VideoPlayer.prepareCompleted事件执行完，则为true
         * 执行VideoPlayer.Stop()，则为false
         * 准备失败，则为false，错误描述通过VideoPlayer.errorReceived事件发送
         */
        print(string.Format("VideoPlayer是否已成功准备要播放的内容：{0}", vp.isPrepared));
        #endregion

        #region playbackSpeed 播放速度
        /*
         * Whether the playback speed can be changed. (Read Only)
         * 只读
         */
        bool canSetPlaybackSpeed = vp.canSetPlaybackSpeed;
        print(string.Format("是否可以更改播放速度：{0}", canSetPlaybackSpeed));

        /*
         * Factor by which the basic playback rate will be multiplied.
         * 即视频剪辑的播放速度的倍数。
         * 对负值的支持取决于平台。
         * 只有当VideoPlayer.canSetPlaybackSpeed=true时有效。
         */
        print(string.Format("基本播放速率相乘因子：{0}", vp.playbackSpeed));
        #endregion

        /*
         * Whether the content will start playing back as soon as the component awakes.
         */
        print(string.Format("一旦组件唤醒，内容是否将开始播放：{0}", vp.playOnAwake));

        /*
         * Where the video content will be drawn.
         */
        vp.renderMode = VideoRenderMode.CameraNearPlane;
        print(string.Format("视频内容将绘制的位置：{0}", vp.renderMode));
        /*
         * VideoRenderMode枚举    Type of destination for the images read by a VideoPlayer.VideoPlayer读取的图像的目标类型。
         *  CameraFarPlane      Draw video content behind a camera's scene.在相机的场景后面绘制视频内容。
         *  CameraNearPlane     Draw video content in front of a camera's scene.在相机场景前绘制视频内容。
         *  RenderTexture       Draw video content into a RenderTexture.将视频内容绘制到RenderTexture中。
         *  MaterialOverride    Draw the video content into a user-specified property of the current GameObject's material.将视频内容绘制到当前GameObject材质的用户指定属性中。
         *  APIOnly             Don't draw the video content anywhere, but still make it available via the VideoPlayer's texture property in the API.不要在任何地方绘制视频内容，但仍然可以通过API中的VideoPlayer纹理属性使其可用。
         */
    }
}